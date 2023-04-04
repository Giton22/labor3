using System.ComponentModel.DataAnnotations;

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

        public new ICollection<SiteUser> Users { get; set;}
        public Job()
        {
            UId = Guid.NewGuid().ToString();
        }
    }
}
