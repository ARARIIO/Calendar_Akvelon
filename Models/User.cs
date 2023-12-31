﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // уникальный идентификатор пользователя

        [Required]
        public string FullName { get; set; } // Имя и фамилия пользователя  

        [Required]
        public string Email { get; set; } // электронная почта пользователя

        [Required]
        public string Password { get; set; } // пароль пользователя

        public ICollection<Event> Events { get; set; }
        public ICollection<Calendar> Calendars { get; set; }

        
    }
}
