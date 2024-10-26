using System.ComponentModel.DataAnnotations;

namespace Picasso.Models
{
    public class Spaces
    {
        [Key]
        public Guid SpaceId { get; set; }

        public string SpaceName { get; set; }

        public string SpaceLocation { get; set; }

        public int SpaceCapacity { get; set; }

        public string SpaceDescription { get; set; }

        public bool SpaceStatus { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
