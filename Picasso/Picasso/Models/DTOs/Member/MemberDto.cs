using System.ComponentModel.DataAnnotations;

namespace Picasso.Models.DTOs.Member
{
    public class MemberDto
    {
        public Guid MemberId { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string MemberPhone { get; set; }

        [Required]
        public string MemberEmail { get; set; }

        public string MemberIdentity { get; set; }

        public string MemberAccount { get; set; }

        public string MemberPassword { get; set; }
    }
}
