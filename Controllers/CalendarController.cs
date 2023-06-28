using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CalendarController> _logger;

        public CalendarController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Calendar> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Calendar
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}