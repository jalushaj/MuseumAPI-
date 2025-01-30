namespace MuseumAPI.Data.Services
{
    public class ExhibitionDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VisitorType { get; set; }
        public string EventType { get; set; }
    }
}