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

        public CalendarDbContext(DbContextOptions<CalendarDbContext> options, DbSet<User> users, DbSet<Event> events, DbSet<Holiday> holidays, DbSet<Models.Calendar> calendars) : base(options)
        {
            Users = users;
            Events = events;
            Holidays = holidays;
            Calendars = calendars;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CalendarDB;Username=postgres;Password=Arari15");
            }
        }
    }
}
