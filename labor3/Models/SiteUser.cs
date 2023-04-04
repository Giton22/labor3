using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace labor3.Models
{
    public class SiteUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int minSalaryPerHour { get; set; }
        [NotMapped]
       public virtual ICollection<Job> Jobs { get; set; }
    }

}
