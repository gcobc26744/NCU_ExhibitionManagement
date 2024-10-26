namespace Picasso.Models.DTOs.Member
{
    public class ExhibitionApplyRecordDto
    {
        public Guid ExhibitionId { get; set; }

        public Guid MemberId { get; set; }

        public Guid SpaceId { get; set; }

        public string ExhibitionName { get; set; }

        public string SpaceName { get; set; }

        public DateTime ApplyDate { get; set; }

        public bool ApplyStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
