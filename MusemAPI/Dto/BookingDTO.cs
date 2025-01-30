namespace MuseumAPI.Data.Services
{
    public class BookingDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public string Card { get; set; }
    }
}
