using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Picasso.Model;
using Picasso.Models;

namespace Picasso.Controllers
{
    public class CurationController : Controller
    {
        private readonly ILogger<CurationController> _logger;
        private readonly ExhibitionManagementDbContext _exhibitionManagementDbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CurationController(ILogger<CurationController> logger, ExhibitionManagementDbContext exhibitionManagementDbContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _exhibitionManagementDbContext = exhibitionManagementDbContext;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// 展覽場地租借(頁面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Apply()
        {
            var memberId = new Guid(HttpContext.Session.GetString("MemberId"));

            var member = _exhibitionManagementDbContext.Members
                            .Where(m => m.MemberId == memberId)
                            .Select(m => new Members
                            {
                                MemberName = m.MemberName,
                                MemberPhone = m.MemberPhone,
                                MemberEmail = m.MemberEmail
                            })
                            .ToList();

            ViewBag.Member = member[0];

            var space = new List<SelectListItem>();

            space = _exhibitionManagementDbContext.Spaces.Select(s => new SelectListItem { Value = s.SpaceId.ToString(), Text = s.SpaceName }).ToList();

            ViewBag.Space = space;

            var exhibitionType = new List<SelectListItem>()
            {
                new SelectListItem { Value = "個人展覽", Text = "個人展覽"},
                new SelectListItem { Value = "專題展覽", Text = "專題展覽"},
                new SelectListItem { Value = "畫展", Text = "畫展"},
                new SelectListItem { Value = "影音展覽", Text = "影音展覽"},
                new SelectListItem { Value = "其他", Text = "其他"}
            };

            ViewBag.ExhibitionType = exhibitionType;

            return View(new Models.DTOs.Curation.ApplyDto());
        }

        /// <summary>
        /// 新增展覽場地租借(動作)
        /// </summary>
        /// <param name="applyDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Apply(Models.DTOs.Curation.ApplyDto applyDto)
        {
            if (ModelState.IsValid)
            {
                var exhibitionDateRecordList = _exhibitionManagementDbContext.Exhibitions
                                            .Where(e => !(e.EndDate < DateTime.Now) && e.SpaceId == applyDto.SpaceId)
                                            .Select(e => new Exhibitions { StartDate = e.StartDate, EndDate = e.EndDate })
                                            .ToList();

                if(exhibitionDateRecordList.Count != 0)
                {
                    foreach (var exhibitionDate in exhibitionDateRecordList)
                    {
                        if ((applyDto.StartDate < exhibitionDate.StartDate) && (applyDto.EndDate > exhibitionDate.StartDate))
                        {
                            TempData["CurationApplyDateError"] = true;
                            break;
                        }
                        else if ((applyDto.StartDate > exhibitionDate.StartDate) && (applyDto.EndDate < exhibitionDate.EndDate))
                        {
                            TempData["CurationApplyDateError"] = true;
                            break;
                        }
                        else if ((applyDto.StartDate < exhibitionDate.EndDate) && (applyDto.EndDate > exhibitionDate.EndDate))
                        {
                            TempData["CurationApplyDateError"] = true;
                            break;
                        }
                        else if ((applyDto.StartDate == exhibitionDate.StartDate) && (applyDto.EndDate == exhibitionDate.EndDate))
                        {
                            TempData["CurationApplyDateError"] = true;
                            break;
                        }
                        else
                        {
                            var AddApplyToDBState = AddApplyToDB(applyDto);

                            if (AddApplyToDBState)
                            {
                                TempData["CurationApplySuccess"] = true;

                                return RedirectToAction("ManagementCenter", "Member");
                            }
                            else
                            {
                                return RedirectToAction("Apply", "Curation");
                            }
                            
                        }
                    }

                    return RedirectToAction("Apply", "Curation");
                }
                else
                {
                    var AddApplyToDBState = AddApplyToDB(applyDto);

                    if (AddApplyToDBState)
                    {
                        TempData["CurationApplySuccess"] = true;

                        return RedirectToAction("ManagementCenter", "Member");
                    }
                    else
                    {
                        return RedirectToAction("Apply", "Curation");
                    }
                }
            }
            else
            {
                return RedirectToAction("Apply", "Curation");
            }
        }

        private bool AddApplyToDB(Models.DTOs.Curation.ApplyDto applyDto)
        {

            //Save image to wwwroot/image/upload/
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(applyDto.ImageFile.FileName);
            string extension = Path.GetExtension(applyDto.ImageFile.FileName);

            applyDto.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/image/upload/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                applyDto.ImageFile.CopyToAsync(fileStream);
            }

            applyDto.ExhibitionStatus = "待審核";

            var memberId = _exhibitionManagementDbContext.Members
                        .Where(m => m.MemberName == applyDto.MemberName)
                        .Select(m => m.MemberId)
                        .FirstOrDefault();

            Exhibitions exhibition = _mapper.Map<Exhibitions>(applyDto);

            exhibition.MemberId = memberId;

            //Insert record
            _exhibitionManagementDbContext.Exhibitions.Add(exhibition);
            _exhibitionManagementDbContext.SaveChanges();

            return true;
        }
    }
}
