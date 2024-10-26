using Microsoft.AspNetCore.Mvc;
using Picasso.Models;
using AutoMapper;
using Picasso.Models.DTOs.ExhibitionApply;
using Microsoft.AspNetCore.Mvc.Rendering;
using Picasso.Model;

namespace Picasso.Controllers
{
    public class ExhibitionApplyController : Controller
    {
        private readonly ILogger<ExhibitionApplyController> _logger;
        private readonly ExhibitionManagementDbContext _exhibitionManagementDbContext;
        private readonly IMapper _mapper;

        public ExhibitionApplyController(ILogger<ExhibitionApplyController> logger, ExhibitionManagementDbContext exhibitionManagementDbContext, IMapper mapper)
        {
            _logger = logger;
            _exhibitionManagementDbContext = exhibitionManagementDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 報名展覽(畫面)
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Apply(Guid exhibitionId)
        {
            var currentMemberId = new Guid(HttpContext.Session.GetString("MemberId"));

            ExhibitionApplyDto exhibitionApplyDto = new ExhibitionApplyDto();

            var exhibition = _exhibitionManagementDbContext.Exhibitions.Find(exhibitionId);
            var exhibitionApply = _exhibitionManagementDbContext.ExhibitionApply.Where(ea => ea.ExhibitionId.Equals(exhibitionId) && ea.ApplyStatus == true);


            var exhibitionDate = GetDateRangeString(exhibition.StartDate, exhibition.EndDate);
            var space = _exhibitionManagementDbContext.Spaces.Find(exhibition.SpaceId);
            var applyCount = exhibitionApply.Count() + " / " + space.SpaceCapacity;
            var member = _exhibitionManagementDbContext.Members.Find(exhibition.MemberId);

            

            exhibitionApplyDto.ExhibitionId = exhibitionId;
            exhibitionApplyDto.ExhibitionName = exhibition.ExhibitionName;
            exhibitionApplyDto.ExhibitionDate = exhibitionDate;
            exhibitionApplyDto.SpaceName = space.SpaceName;
            exhibitionApplyDto.ApplyCount = applyCount;
            exhibitionApplyDto.MemberName = member.MemberName;
            exhibitionApplyDto.MemberIdentity = member.MemberIdentity;
            exhibitionApplyDto.ApplyStatus = exhibitionApply.Where(ea => ea.MemberId == currentMemberId).Select(ea => ea.ApplyStatus).FirstOrDefault();
            exhibitionApplyDto.MemberId = currentMemberId;

            if (exhibitionApply.Count() == space.SpaceCapacity)
            {
                exhibitionApplyDto.IsSpaceCapacityFull = true;
            }

            var applyDateList = new List<SelectListItem>();

            if (!exhibitionApplyDto.ApplyStatus && !exhibitionApplyDto.IsSpaceCapacityFull)
            {
                DateTime calcDate = exhibition.StartDate;

                while (calcDate <= exhibition.EndDate)
                {

                    applyDateList.Add(new SelectListItem { Value = calcDate.ToString("yyyy/MM/dd"), Text = calcDate.ToString("yyyy/MM/dd") });
                    calcDate = calcDate.AddDays(1);
                }

                ViewBag.ApplyDateList = applyDateList;
            }
            else if (exhibitionApplyDto.ApplyStatus)
            {
                var currentMemberApplyDate = exhibitionApply.Where(ea => ea.MemberId == currentMemberId).Select(ea => ea.ApplyDate).FirstOrDefault();

                applyDateList.Add(new SelectListItem { Value = currentMemberApplyDate.ToString("yyyy/MM/dd"), Text = currentMemberApplyDate.ToString("yyyy/MM/dd") });

                ViewBag.ApplyDateList = applyDateList;
            }
            else if(exhibitionApplyDto.IsSpaceCapacityFull)
            {
                applyDateList.Add(new SelectListItem { Value = "", Text = "" });

                ViewBag.ApplyDateList = applyDateList;
            }

            return View(exhibitionApplyDto);
        }

        /// <summary>
        /// 報名展覽(動作)
        /// </summary>
        /// <param name="exhibitionApplyDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Apply(ExhibitionApplyDto exhibitionApplyDto)
        {
            if (ModelState.IsValid)
            {
                var exhibitionApply = new ExhibitionApply();

                exhibitionApply.MemberId = new Guid(HttpContext.Session.GetString("MemberId"));
                exhibitionApply.ExhibitionId = exhibitionApplyDto.ExhibitionId;
                exhibitionApply.ApplyDate = exhibitionApplyDto.ApplyDate;
                exhibitionApply.ApplyStatus = true;

                _exhibitionManagementDbContext.ExhibitionApply.Add(exhibitionApply);
                _exhibitionManagementDbContext.SaveChanges();

                TempData["ExhibitionApplySuccess"] = true;

                return RedirectToAction("ManagementCenter", "Member"); //action, controller 
            }
            else
            {
                return View(exhibitionApplyDto);
            }
        }

        static string GetDateRangeString(DateTime startDate, DateTime endDate)
        {
            return startDate.ToString("yyyy/MM/dd") + " - " + endDate.ToString("yyyy/MM/dd");
        }
    }
}
