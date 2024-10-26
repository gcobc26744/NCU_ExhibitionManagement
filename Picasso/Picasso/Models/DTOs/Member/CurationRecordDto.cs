namespace Picasso.Models.DTOs.Member
{
    public class CurationRecordDto
    {
        public Guid ExhibitionId { get; set; }

        public Guid MemberId { get; set; }

        public string ExhibitionName { get; set; }

        public string SpaceName { get; set; }

        public string ExhibitionDate { get; set; }

        public string ExhibitionStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
