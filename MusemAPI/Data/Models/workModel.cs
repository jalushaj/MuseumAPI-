using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekti.Models
{
    public class workModel
    {
  
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }

        [Column("creation_date_text")]
        public string? CreationDateText { get; set; }

        public required string Era { get; set; }
    }

}

