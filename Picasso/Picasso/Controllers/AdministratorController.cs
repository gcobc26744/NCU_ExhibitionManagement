using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Picasso.Models;
using Picasso.Models.DTOs.Administrator;

namespace Picasso.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly ILogger<AdministratorController> _logger;
        private readonly ExhibitionManagementDbContext _exhibitionManagementDbContext;
        private readonly IMapper _mapper;

        public AdministratorController(ILogger<AdministratorController> logger, ExhibitionManagementDbContext exhibitionManagementDbContext, IMapper mapper)
        {
            _logger = logger;
            _exhibitionManagementDbContext = exhibitionManagementDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 系統管理員首頁(畫面)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 系統管理員登出(動作)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Exhibition"); //action, controller
        }

        /// <summary>
        /// 系統管理員變更密碼(畫面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }

        /// <summary>
        /// 系統管理員變更密碼(動作)
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdatePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var administratorId = new Guid(HttpContext.Session.GetString("AdministratorId"));

            var administrator = _exhibitionManagementDbContext.Administrators.Where(a => a.AdministratorId == administratorId).FirstOrDefault();

            if ((administrator.AdministratorPassword == oldPassword) && (oldPassword != newPassword) && (newPassword == confirmPassword))
            {
                administrator.AdministratorPassword = newPassword;

                _exhibitionManagementDbContext.Administrators.Update(administrator);

                _exhibitionManagementDbContext.SaveChanges();

                TempData["UpdateAdministratorPasswordSuccess"] = true;

                return RedirectToAction("UpdatePassword", "Administrator");
            }
            else
            {
                TempData["UpdateAdministratorPasswordError"] = true;

                return RedirectToAction("UpdatePassword", "Administrator");
            }
        }

        /// <summary>
        /// 系統管理員策展管理(畫面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ReviewCuration()
        {
            int item = 0;

            List<ReviewCurationDto> reviewCurationDto = new List<ReviewCurationDto>();

            var exhibitionList = _exhibitionManagementDbContext.Exhibitions
                                .OrderByDescending(e => e.CreateDate)
                                .ToList();


            foreach (var exhibition in exhibitionList)
            {
                var memberName = _exhibitionManagementDbContext.Members
                                .Where(m => m.MemberId == exhibition.MemberId)
                                .Select(m => m.MemberName)
                                .FirstOrDefault();

                var spaceName = _exhibitionManagementDbContext.Spaces
                                .Where(m => m.SpaceId == exhibition.SpaceId)
                                .Select(m => m.SpaceName)
                                .FirstOrDefault();

                reviewCurationDto.Add(_mapper.Map<ReviewCurationDto>(exhibition));

                reviewCurationDto[item].ExhibitionId = exhibition.ExhibitionId;
                reviewCurationDto[item].ApplyDate = exhibition.CreateDate.ToString("yyyy/MM/dd HH:mm");
                reviewCurationDto[item].MemberName = memberName;
                reviewCurationDto[item].SpaceName = spaceName;
                
                item++;
            }

            return View(reviewCurationDto);
        }

        /// <summary>
        /// 系統管理員審核策展(畫面)
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ReviewCurationDetail(Guid exhibitionId)
        {
            var reviewCurationDetailDto = _exhibitionManagementDbContext.Exhibitions
                    .Join(_exhibitionManagementDbContext.Members,
                            e => e.MemberId,
                            m => m.MemberId,
                            (e, m) => new ReviewCurationDetailDto
                            {
                                ExhibitionId = e.ExhibitionId,
                                SpaceId = e.SpaceId,
                                MemberName = m.MemberName,
                                MemberPhone = m.MemberPhone,
                                MemberEmail = m.MemberEmail,
                                ExhibitionName = e.ExhibitionName,
                                ExhibitionType = e.ExhibitionType,
                                ExhibitionDescription = e.ExhibitionDescription,
                                Image = e.Image,
                                Organizer = e.Organizer,
                                CoOrganizer = e.CoOrganizer,
                                StartDate = e.StartDate,
                                EndDate = e.EndDate,
                                ExhibitionStatus = e.ExhibitionStatus
                            })
                    .Join(_exhibitionManagementDbContext.Spaces,
                            o => o.SpaceId,
                            s => s.SpaceId,
                            (o, s) => new ReviewCurationDetailDto
                            {
                                ExhibitionId = o.ExhibitionId,
                                MemberName = o.MemberName,
                                MemberPhone = o.MemberPhone,
                                MemberEmail = o.MemberEmail,
                                ExhibitionName = o.ExhibitionName,
                                ExhibitionType = o.ExhibitionType,
                                ExhibitionDescription = o.ExhibitionDescription,
                                Image = o.Image,
                                Organizer = o.Organizer,
                                CoOrganizer = o.CoOrganizer,
                                StartDate = o.StartDate,
                                EndDate = o.EndDate,
                                ExhibitionStatus = o.ExhibitionStatus,
                                SpaceName = s.SpaceName
                            })
                    .Where(e => e.ExhibitionId == exhibitionId)
                    .FirstOrDefault();

            var exhibitionStatus = new List<SelectListItem>()
            {
                new SelectListItem { Value = "待審核", Text = "待審核"},
                new SelectListItem { Value = "通過", Text = "通過"},
                new SelectListItem { Value = "失敗", Text = "失敗"},
            };

            ViewBag.ExhibitionStatus = exhibitionStatus;

            if (!(reviewCurationDetailDto.ExhibitionStatus == "待審核"))
            {
                TempData["ReviewedCuration"] = true;
            }

            return View(reviewCurationDetailDto);
        }

        /// <summary>
        /// 系統管理員審核策展(動作)
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="exhibitionStatus"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ReviewCurationDetail(Guid exhibitionId, string exhibitionStatus)
        {
            if (!(exhibitionStatus == "待審核"))
            {
                var exhibition = _exhibitionManagementDbContext.Exhibitions
                                .Where(e => e.ExhibitionId == exhibitionId)
                                .FirstOrDefault();

                exhibition.ExhibitionStatus = exhibitionStatus;

                _exhibitionManagementDbContext.Exhibitions.UpdateRange(exhibition);
                _exhibitionManagementDbContext.SaveChanges();

                TempData["ReviewedCuration"] = true;

                return Json(true);
            }
            else
            {
                TempData["ReviewedCuration"] = false;

                return Json(false);
            }
        }

        /// <summary>
        /// 系統管理員會員管理(畫面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MemberManagement()
        {
            var memberList = _exhibitionManagementDbContext.Members.ToList();

            return View(memberList);
        }

        /// <summary>
        /// 系統管理員刪除會員(動作)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DeleteMember(Guid memberId)
        {
            _exhibitionManagementDbContext.Members.Remove(_exhibitionManagementDbContext.Members.Single(m => m.MemberId == memberId));
            _exhibitionManagementDbContext.SaveChanges();

            return Json(true);
        }
    }
}
