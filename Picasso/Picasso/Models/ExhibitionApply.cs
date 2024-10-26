using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picasso.Model
{
    public class ExhibitionApply
    {
        [Key]
        public Guid ApplyId { get; set; }

        public Guid MemberId { get; set; }

        public Guid ExhibitionId { get; set; }

        public DateTime ApplyDate { get; set; }

        public bool ApplyStatus { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
