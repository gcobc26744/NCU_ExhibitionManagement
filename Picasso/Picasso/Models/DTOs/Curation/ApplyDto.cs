using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picasso.Models.DTOs.Curation
{
    public class ApplyDto
    {
        public string MemberName { get; set; }

        public string MemberPhone { get; set; }

        public string MemberEmail { get; set; }

        [Required]
        public string ExhibitionName { get; set; }

        [Required]
        public Guid SpaceId { get; set; }

        [Required]
        public string ExhibitionType { get; set; }

        [Required]
        public string ExhibitionDescription { get; set; }

        public string Image { get; set; }

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public string Organizer { get; set; }

        [Required]
        public string CoOrganizer { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string ExhibitionStatus { get; set; } 
    }
}
