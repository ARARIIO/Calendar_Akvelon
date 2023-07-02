using System.Collections.Generic;
using Calendar.Context;
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly CalendarDbContext _context;

        public HolidayController(CalendarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Holiday> GetHolidays()
        {
            return _context.Holidays;
        }

        [HttpGet("{id}")]
        public ActionResult<Holiday> GetHoliday(int id)
        {
            var holiday = _context.Holidays.Find(id);
            if (holiday == null)
            {
                return NotFound();
            }
            return holiday;
        }

        [HttpPost]
        public ActionResult<Holiday> CreateHoliday(Holiday holiday)
        {
            _context.Holidays.Add(holiday);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHoliday), new { id = holiday.Id }, holiday);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHoliday(int id, Holiday updatedHoliday)
        {
            var existingHoliday = _context.Holidays.Find(id);
            if (existingHoliday == null)
            {
                return NotFound();
            }

            existingHoliday.Name = updatedHoliday.Name;
            existingHoliday.Date = updatedHoliday.Date;

            _context.Update(existingHoliday);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteHoliday(int id)
        {
            var holiday = _context.Holidays.Find(id);
            if (holiday == null)
            {
                return NotFound();
            }
            _context.Holidays.Remove(holiday);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
