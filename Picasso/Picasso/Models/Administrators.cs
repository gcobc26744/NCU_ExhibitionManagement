using System.ComponentModel.DataAnnotations;

namespace Picasso.Model
{
    public class Administrators
    {
        [Key]
        public Guid AdministratorId { get; set; }

        public string AdministratorAccount { get; set; }

        public string AdministratorPassword { get; set; }

        public string AdministratorName { get; set; }

        public string AdministratorPhone { get; set; }

        public string AdministratorEmail { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
