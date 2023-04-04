using MessagePack;

namespace labor3.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
