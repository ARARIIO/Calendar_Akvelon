using System.Collections.Generic;
using Calendar.Context;
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public CalendarController(CalendarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Models.Calendar> GetCalendars()
        {
            return _context.Calendars;
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Calendar> GetCalendar(int id)
        {
            var calendar = _context.Calendars.Find(id);
            if (calendar == null)
            {
                return NotFound();
            }
            return calendar;
        }

        [HttpPost]
        public ActionResult<Models.Calendar> CreateCalendar(Models.Calendar calendar)
        {
            _context.Calendars.Add(calendar);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCalendar), new { id = calendar.Id }, calendar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCalendar(int id, Models.Calendar updatedCalendar)
        {
            var calendar = _context.Calendars.Find(id);
            if (calendar == null)
            {
                return NotFound();
            }

            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCalendar(int id)
        {
            var calendar = _context.Calendars.Find(id);
            if (calendar == null)
            {
                return NotFound();
            }

            _context.Remove(calendar);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
