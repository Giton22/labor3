using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace labor3.Models
{
    public class Job
    {
        [Key]
        public string UId { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public virtual ICollection<SiteUser> Users { get; set;}
        public Job()
        {
            UId = Guid.NewGuid().ToString();
        }
    }
}
