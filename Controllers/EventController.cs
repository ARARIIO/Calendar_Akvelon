using System.Collections.Generic;
using Calendar.Context;
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public EventController(CalendarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return _context.Events;
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(int id)
        {
            var @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return @event;
        }

        [HttpPost]
        public ActionResult<Event> CreateEvent(Event evnt)
        {
            _context.Events.Add(evnt);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEvent), new { id = evnt.Id }, evnt);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            updatedEvent.Id = id; // Установка идентификатора события
            _context.Update(updatedEvent);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var existingEvent = _context.Events.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            _context.Remove(existingEvent);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
