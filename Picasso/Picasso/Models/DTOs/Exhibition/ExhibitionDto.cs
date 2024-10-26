namespace Picasso.Models.DTOs.Exhibition
{
    public class ExhibitionDto
    {
        public string ExhibitionId { get; set; }

        public string ExhibitionName { get; set; }

        public string MemberName { get; set; }

        public string SpaceName { get; set; }

        public string ExhibitionDate { get; set; }

        public string Organizer { get; set; }

        public string CoOrganizer { get; set; }

        public string ExhibitionDescription { get; set; }

        public string Image { get; set; }

        public Guid SpaceId { get; set; }

        public bool IsPastExhibition { get; set; }
    }
}
