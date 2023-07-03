using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class Holiday
    {
        
        public int Id { get; set; } // уникальный идентификатор праздника
        
        [Required]
        public string Name { get; set; } // название праздника
        
        public DateTime Date { get; set; } // дата праздника
    }
}
