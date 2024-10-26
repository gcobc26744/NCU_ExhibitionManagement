using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Picasso.Model;
using Picasso.Models;
using Picasso.Models.DTOs.Exhibition;

namespace Picasso.Controllers
{
    public class ExhibitionController : Controller
    {
        private readonly ILogger<ExhibitionController> _logger;
        private readonly ExhibitionManagementDbContext _exhibitionManagementDbContext;
        private readonly IMapper _mapper;

        public ExhibitionController(ILogger<ExhibitionController> logger, ExhibitionManagementDbContext exhibitionManagementDbContext, IMapper mapper)
        {
            _logger = logger;
            _exhibitionManagementDbContext = exhibitionManagementDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 首頁(畫面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 活動總攬(畫面)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Overview()
        {
            int item = 0;

            List<ExhibitionDto> exhibitionDetailDto = new List<ExhibitionDto>();

            List<Exhibitions> exhibitionList = new List<Exhibitions>();

            var spaceIdList = _exhibitionManagementDbContext.Spaces.Select(s => s.SpaceId).ToList();

            if (TempData["ExhibitionList"] != null)
            {
                exhibitionList = JsonConvert.DeserializeObject<List<Exhibitions>>(TempData["ExhibitionList"].ToString());
            }
            else
            {
                var spaceId = spaceIdList[0];

                exhibitionList = _exhibitionManagementDbContext.Exhibitions
                                .Where(e => e.SpaceId == spaceId && (e.ExhibitionStatus == "通過") && (e.StartDate < DateTime.Now && e.EndDate > DateTime.Now))
                                .OrderByDescending(e => e.StartDate)
                                .ToList();
            }
            
            foreach (var exhibition in exhibitionList)
            {
                var exhibitionDate = GetDateRangeString(exhibition.StartDate, exhibition.EndDate);

                var exhibitionSpaceName = _exhibitionManagementDbContext.Spaces
                                .Where(s => s.SpaceId == exhibition.SpaceId)
                                .Select(s => s.SpaceName)
                                .FirstOrDefault();

                var memberName = _exhibitionManagementDbContext.Members
                                .Where(m => m.MemberId == exhibition.MemberId)
                                .Select(m => m.MemberName)
                                .FirstOrDefault();

                exhibitionDetailDto.Add(_mapper.Map<ExhibitionDto>(exhibition));

                exhibitionDetailDto[item].ExhibitionDate = exhibitionDate;
                exhibitionDetailDto[item].SpaceName = exhibitionSpaceName;
                exhibitionDetailDto[item].MemberName = memberName;
                exhibitionDetailDto[item].Image = exhibition.Image;

                item++;
            }

            return View(exhibitionDetailDto);
        }

        /// <summary>
        /// 活動總攬(動作)
        /// </summary>
        /// <param name="spaceName"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetOverview(string spaceName, string period)
        {
            var spaceId = Guid.Empty;

            List<Exhibitions> exhibitionList = new List<Exhibitions>();

            var spaceIdList = _exhibitionManagementDbContext.Spaces
                            .Where(s => s.SpaceName == spaceName)
                            .Select(s => s.SpaceId)
                            .FirstOrDefault();

            switch (spaceName)
            {
                case null:
                    spaceId = spaceIdList;
                    break;

                case "人文藝術中心":
                    spaceId = spaceIdList;
                    break;

                case "107電影院":
                    spaceId = spaceIdList;
                    break;

                case "黑盒子劇場":
                    spaceId = spaceIdList;
                    break;
            }

            if (string.IsNullOrWhiteSpace(period) || (period == "null"))
            {
                period = "current";
            }

            switch (period)
            {
                case "current":

                    exhibitionList = _exhibitionManagementDbContext.Exhibitions
                            .Where(e => e.SpaceId == spaceId && (e.ExhibitionStatus == "通過") && (e.StartDate < DateTime.Now && e.EndDate > DateTime.Now))
                            .OrderByDescending(e => e.StartDate)
                            .ToList();
                    break;

                case "future":

                    exhibitionList = _exhibitionManagementDbContext.Exhibitions
                            .Where(e => e.SpaceId == spaceId && (e.ExhibitionStatus == "通過") && (e.StartDate > DateTime.Now))
                            .OrderByDescending(e => e.StartDate)
                            .ToList();
                    break;

                case "past":

                    exhibitionList = _exhibitionManagementDbContext.Exhibitions
                            .Where(e => e.SpaceId == spaceId && (e.ExhibitionStatus == "通過") && (e.EndDate < DateTime.Now))
                            .OrderByDescending(e => e.StartDate)
                            .ToList();
                    break;

            }

            TempData["ExhibitionList"] = JsonConvert.SerializeObject(exhibitionList);
            TempData["Period"] = period;

            return Json(true);
        }

        /// <summary>
        /// 展覽詳細資訊(畫面&動作)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail(Guid exhibitionId)
        {
            var exhibition = _exhibitionManagementDbContext.Exhibitions.Find(exhibitionId);

            var exhibitionDate = GetDateRangeString(exhibition.StartDate, exhibition.EndDate);
            var spaceName = (_exhibitionManagementDbContext.Spaces.Find(exhibition.SpaceId)).SpaceName;
            var memberName = (_exhibitionManagementDbContext.Members.Find(exhibition.MemberId)).MemberName;

            ExhibitionDto exhibitionDto = _mapper.Map<ExhibitionDto>(exhibition);

            if (exhibition.EndDate < DateTime.Now)
            {
                exhibitionDto.IsPastExhibition = true;
            }

            exhibitionDto.ExhibitionDate = exhibitionDate;
            exhibitionDto.SpaceName = spaceName;
            exhibitionDto.MemberName = memberName;

            return View(exhibitionDto);
        }

        /// <summary>
        /// 展場介紹(畫面&動作)
        /// </summary>
        /// <param name="spaceName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SpaceDetail(string spaceName)
        {
            if (spaceName == null)
            {
                var space = _exhibitionManagementDbContext.Spaces.ToList();

                return View(space);
            }
            else
            {
                var space = _exhibitionManagementDbContext.Spaces.Where(s => s.SpaceName == spaceName).ToList();

                return View(space);
            }
        }

        static string GetDateRangeString(DateTime startDate, DateTime endDate)
        {
            return startDate.ToString("yyyy/MM/dd") + " - " + endDate.ToString("yyyy/MM/dd");
        }
    }
}
