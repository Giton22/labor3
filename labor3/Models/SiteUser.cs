using Microsoft.AspNetCore.Identity;

namespace labor3.Models
{
    public class SiteUser:IdentityUser
    {
        public int minSalaryPerHour { get; set; }
        public Role Role { get; set; }

       public  ICollection<Job> Jobs { get; set; }
    }

    public enum Role {ADMIN,USER }
}
