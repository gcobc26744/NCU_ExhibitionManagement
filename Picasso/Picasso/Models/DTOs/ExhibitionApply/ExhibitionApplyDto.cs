using System.ComponentModel.DataAnnotations;

namespace Picasso.Models.DTOs.ExhibitionApply
{
    public class ExhibitionApplyDto
    {
        public Guid ExhibitionId { get; set; }

        public Guid MemberId { get; set; }

        public string ExhibitionName { get; set; }

        public string ExhibitionDate { get; set; }

        public string SpaceName { get; set; }

        [Required]
        public DateTime ApplyDate { get; set; }

        public string ApplyCount { get; set; }

        public bool ApplyStatus { get; set; }

        public string MemberName { get; set; }

        public string MemberIdentity { get; set; }

        public bool IsSpaceCapacityFull { get; set; }
    }
}
