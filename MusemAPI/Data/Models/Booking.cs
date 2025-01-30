using System;
using System.ComponentModel.DataAnnotations;

namespace MuseumAPI.Data.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public string Card { get; set; } 
    }
}
