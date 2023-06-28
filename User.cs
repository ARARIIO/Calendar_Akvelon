namespace Calendar
{
    public class User
    {
        public int Id { get; set; } // уникальный идентификатор пользователя
        public required string FullName { get; set; } // Имя и фамилия пользователя  
        public required string Email { get; set; } // электронная почта пользователя
        public required string Password { get; set; } // пароль пользователя

        public required ICollection<Event> Events { get; set; }
        public required ICollection<Calendar> Calendars { get; set; }

        public User()
        {
            Events = new List<Event>();
            Calendars = new List<Calendar>();
        }
    }
}
