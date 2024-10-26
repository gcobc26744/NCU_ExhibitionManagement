using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picasso.Model
{
    public class Exhibitions
    {
        [Key]
        public Guid ExhibitionId { get; set; }

        public Guid SpaceId { get; set; }

        public Guid MemberId { get; set; }

        public string ExhibitionName { get; set; }

        public string ExhibitionType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Organizer { get; set; }

        public string CoOrganizer { get; set; }

        public string ExhibitionDescription { get; set; }

        public string ExhibitionStatus { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
