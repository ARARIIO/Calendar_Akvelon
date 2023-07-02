
namespace Calendar.Models
{
    public abstract class Event
    {
        public int Id { get; set; } // уникальный идентификатор события
        public string? Title { get; set; } // название события
        public DateTime Date { get; set; } // дата события
        public string? Description { get; set; } // описание события
        public int UserId { get; set; } // идентификатор пользователя, к которому относится событие

        public required User User { get; set; }

        protected Event(User user)
        {
            User = user;
            UserId = user.Id;
            user.Events.Add(this);
        }
    }
}
