namespace Picasso.Models.DTOs.Administrator
{
    public class ReviewCurationDto
    {
        public Guid ExhibitionId { get; set; }

        public string ApplyDate { get; set; }

        public string MemberName { get; set; }

        public string SpaceName { get; set; }

        public string ExhibitionType { get; set; }

        public string ExhibitionStatus { get; set; }
    }
}
