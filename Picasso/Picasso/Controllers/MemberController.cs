using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Picasso.Model;
using Picasso.Models;
using Picasso.Models.DTOs.Member;

namespace Picasso.Controllers
{
    public class MemberController : Controller
    {

        private readonly ILogger<MemberController> _logger;
        private readonly ExhibitionManagementDbContext _exhibitionManagementDbContext;
        private readonly IMapper _mapper;

        public MemberController(ILogger<MemberController> logger, ExhibitionManagementDbContext exhibitionManagementDbContext, IMapper mapper)
        {
            _logger = logger;
            _exhibitionManagementDbContext = exhibitionManagementDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 會員登入(動作)
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string account, string password)
        {
            string loginIdentity = "";

            HttpContext.Session.Clear();

            var member = _exhibitionManagementDbContext.Members
                        .Where(m => m.MemberAccount == account && m.MemberPassword == password)
                        .FirstOrDefault();

            var administrator = _exhibitionManagementDbContext.Administrators
                .Where(a => a.AdministratorAccount ==  account && a.AdministratorPassword == password)
                .FirstOrDefault();

            if (member != null)
            {
                HttpContext.Session.SetString("MemberId", member.MemberId.ToString());
                HttpContext.Session.SetString("MemberAccount", account);
                HttpContext.Session.SetString("IsLogin", "true");

                loginIdentity = "member";
                return Json(loginIdentity);
            }
            else if (administrator != null)
            {
                HttpContext.Session.SetString("AdministratorId", administrator.AdministratorId.ToString());
                HttpContext.Session.SetString("AdministratorAccount", account);
                HttpContext.Session.SetString("IsLogin", "true");

                loginIdentity = "Administrator";
                return Json(loginIdentity);
            }
            else
            {
                loginIdentity = "";
                return Json(loginIdentity);
            }
        }

        /// <summary>
        /// 會員登出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Exhibition"); //action, controller
        }

        /// <summary>
        /// 會員註冊(動作)
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Register(string account, string password, string confirmPassword, string username, string memberPhone, string memberEmail)
        {
            if (ModelState.IsValid)
            {
                if (password == confirmPassword)
                {
                    var member = new Members()
                    {
                        MemberAccount = account,
                        MemberPassword = password,
                        MemberName = username,
                        MemberPhone = memberPhone,
                        MemberEmail = memberEmail
                    };

                    if (memberEmail.Contains("@gmail.com"))
                    {
                        member.MemberIdentity = "校外人士";

                        _exhibitionManagementDbContext.Members.Add(member);
                        _exhibitionManagementDbContext.SaveChanges();

                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 檢查會員名稱是否已註冊(動作)
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CheckMemberAccountDuplicate(string account)
        {
            var memberAccount = _exhibitionManagementDbContext.Members.Where(m => m.MemberAccount == account).FirstOrDefault();

            if (memberAccount == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 會員中心(會員&動作)
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ManagementCenter(Guid memberId)
        {
            if(memberId == Guid.Empty)
            {
                memberId = new Guid(HttpContext.Session.GetString("MemberId"));
            }

            var managementCenterDto = new ManagementCenterDto();

            //會員資料
            var member = _exhibitionManagementDbContext.Members.Find(memberId);

            managementCenterDto.Member = _mapper.Map<MemberDto>(member);

            //看展紀錄
            var exhibitionApplyRecordList = _exhibitionManagementDbContext.ExhibitionApply
                                            .Join(_exhibitionManagementDbContext.Exhibitions,
                                                  ea => ea.ExhibitionId,
                                                  e => e.ExhibitionId,
                                                  (ea, e) => new ExhibitionApplyRecordDto
                                                  {
                                                      ExhibitionId = e.ExhibitionId,
                                                      SpaceId = e.SpaceId,
                                                      MemberId = ea.MemberId,
                                                      ExhibitionName = e.ExhibitionName,
                                                      StartDate = e.StartDate,
                                                      EndDate = e.EndDate,
                                                      ApplyDate = ea.ApplyDate,
                                                      ApplyStatus = ea.ApplyStatus
                                                  })
                                            .Join(_exhibitionManagementDbContext.Spaces,
                                                  o => o.SpaceId,
                                                  s => s.SpaceId,
                                                  (o, s) => new ExhibitionApplyRecordDto
                                                  {
                                                      ExhibitionId = o.ExhibitionId,
                                                      MemberId = o.MemberId,
                                                      ExhibitionName = o.ExhibitionName,
                                                      StartDate = o.StartDate,
                                                      EndDate = o.EndDate,
                                                      ApplyDate = o.ApplyDate,
                                                      ApplyStatus = o.ApplyStatus,
                                                      SpaceName = s.SpaceName
                                                  })
                                            .Where(o => o.MemberId == memberId && o.ApplyStatus == true)
                                            .OrderByDescending(o => o.ApplyDate)
                                            .ToList();

            managementCenterDto.ExhibitionApplyRecords = exhibitionApplyRecordList;

            //辦展紀錄
            var curationRecordList = _exhibitionManagementDbContext.Exhibitions
                                    .Join(_exhibitionManagementDbContext.Spaces,
                                        e => e.SpaceId,
                                        s => s.SpaceId,
                                        (e, s) => new CurationRecordDto
                                        {
                                            ExhibitionId = e.ExhibitionId,
                                            MemberId = e.MemberId,
                                            ExhibitionName = e.ExhibitionName,
                                            SpaceName = s.SpaceName,
                                            ExhibitionDate = e.StartDate.ToString("yyyy/MM/dd") + " - " + e.EndDate.ToString("yyyy/MM/dd"),
                                            ExhibitionStatus = e.ExhibitionStatus,
                                            StartDate = e.StartDate,
                                            EndDate = e.EndDate
                                        })
                                    .Where(e => e.MemberId == memberId)
                                    .OrderBy(e => e.StartDate)
                                    .ToList();

            managementCenterDto.CurationRecords = curationRecordList;

            return View(managementCenterDto);
        }

        /// <summary>
        /// 變更會員資料(動作)
        /// </summary>
        /// <param name="memberDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateMember(MemberDto memberDto)
        {
            if (ModelState.IsValid)
            {
                var member = _mapper.Map<Members>(memberDto);

                _exhibitionManagementDbContext.Members.Update(member);

                _exhibitionManagementDbContext.SaveChanges();

                TempData["UpdateMemberSuccess"] = true;

                return RedirectToAction("ManagementCenter", "Member"); //action, controller
            }
            else
            {
                return RedirectToAction("ManagementCenter", "Member");
            }
        }

        /// <summary>
        /// 會員變更密碼(動作)
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateMemberPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var memberId = new Guid(HttpContext.Session.GetString("MemberId"));

            var member = _exhibitionManagementDbContext.Members.Where(m => m.MemberId == memberId).FirstOrDefault();

            if ((member.MemberPassword == oldPassword) && (oldPassword != newPassword) && (newPassword == confirmPassword))
            {
                member.MemberPassword = newPassword;

                _exhibitionManagementDbContext.Members.Update(member);

                _exhibitionManagementDbContext.SaveChanges();

                TempData["UpdateMemberPasswordSuccess"] = true;

                return RedirectToAction("ManagementCenter", "Member");
            }
            else
            {
                TempData["UpdateMemberPasswordError"] = true;

                return RedirectToAction("ManagementCenter", "Member"); 
            }
        }

        /// <summary>
        /// 刪除看展紀錄(動作)
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteExhibitionApplyRecord(Guid exhibitionId, Guid memberId)
        {
            var exhibitionApply = _exhibitionManagementDbContext.ExhibitionApply
                                .Where(ea => ea.ExhibitionId == exhibitionId && ea.MemberId == memberId)
                                .OrderByDescending(ea => ea.CreateDate)
                                .FirstOrDefault();

            exhibitionApply.ApplyStatus = false;

            _exhibitionManagementDbContext.ExhibitionApply.UpdateRange(exhibitionApply);
            _exhibitionManagementDbContext.SaveChanges();

            TempData["DeleteExhibitionApplySuccess"] = true;

            return RedirectToAction("ManagementCenter", "Member");
        }

        /// <summary>
        /// 刪除策展紀錄(動作)
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteCurationRecord(Guid exhibitionId, Guid memberId)
        {
            _exhibitionManagementDbContext.Exhibitions
                .Remove(_exhibitionManagementDbContext.Exhibitions
                .Single(e => e.ExhibitionId == exhibitionId && e.MemberId == memberId));
            
            _exhibitionManagementDbContext.SaveChanges();

            TempData["DeleteCurationRecordSuccess"] = true;

            return RedirectToAction("ManagementCenter", "Member");
        }
    }
}
