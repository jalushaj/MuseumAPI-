using System.ComponentModel.DataAnnotations;

namespace MuseumAPI.Data.Models
{
    
    public class Exhibition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VisitorType { get; set; }
        public string EventType { get; set; }
    }
}
