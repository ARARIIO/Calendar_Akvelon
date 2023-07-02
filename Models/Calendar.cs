namespace Calendar.Models
{
    public class Calendar
    {
        public int Id { get; set; } // уникальный идентификатор календаря
        public int UserId { get; set; } // идентификатор пользователя, к которому относится календарь

        public required User User { get; set; }

        public Calendar(User user)
        {
            User = user;
            UserId = user.Id;
            user.Calendars.Add(this);
        }
    }
}
