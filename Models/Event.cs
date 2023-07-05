using System;
using System.ComponentModel.DataAnnotations;
using Calendar.Models;

namespace Calendar.Models
{
    public class Event
    {
        public int Id { get; set; } // уникальный идентификатор события
        public string Title { get; set; } // название события
        public DateTime Date { get; set; } // дата события
        public string Description { get; set; } // описание события

    }
}
