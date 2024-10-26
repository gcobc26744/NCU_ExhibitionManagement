using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Picasso.Model
{
    [Index(nameof(MemberAccount), IsUnique = true)]
    public class Members
    {
        [Key]
        public Guid MemberId { get; set; }

        [Required]
        public string MemberAccount { get; set; }

        [Required]
        public string MemberPassword { get; set; }

        [Required]
        public string MemberName { get; set; }

        public string MemberIdentity { get; set; }

        [Required]
        public string MemberPhone { get; set; }

        [Required]
        public string MemberEmail { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
    