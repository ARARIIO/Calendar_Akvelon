using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Context
{
    public class CalendarDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Models.Calendar> Calendars { get; set; }

        protected CalendarDbContext(DbSet<User> users, DbSet<Event> events, DbSet<Holiday> holidays, DbSet<Models.Calendar> calendars)
        {
            Users = users;
            Events = events;
            Holidays = holidays;
            Calendars = calendars;
        }

        public CalendarDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
