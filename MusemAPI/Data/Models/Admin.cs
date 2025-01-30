using System.ComponentModel.DataAnnotations;

namespace MuseumAPI.Data.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Consider encrypting in a real application
    }
}
