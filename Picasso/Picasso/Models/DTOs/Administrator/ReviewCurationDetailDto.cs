namespace Picasso.Models.DTOs.Administrator
{
    public class ReviewCurationDetailDto
    {
        public Guid ExhibitionId { get; set; }

        public Guid SpaceId { get; set; }

        public string MemberName { get; set; }

        public string MemberPhone { get; set; }

        public string MemberEmail { get; set; }

        public string ExhibitionName { get; set; }

        public string SpaceName { get; set; }

        public string ExhibitionType { get; set; }

        public string ExhibitionDescription { get; set; }

        public string Image { get; set; }

        public string Organizer { get; set; }

        public string CoOrganizer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ExhibitionStatus { get; set; }
    }
}
