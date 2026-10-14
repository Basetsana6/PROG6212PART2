using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // Provides weather snapshots associated with race events.
    [ApiController]
    [Route("api/events/{eventId}/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        public WeatherController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/events/5/weather
        [HttpGet]
        public async Task<IActionResult> GetWeather(int eventId)
        {
            // Retrieve the latest available weather snapshot.
            var weather = await _context.WeatherSnapshots
          .Where(w => w.EventId == eventId)
          .OrderByDescending(w => w.RetrievedAt)
          .FirstOrDefaultAsync();

            if (weather == null)
                return NotFound("No weather information is available.");

            return Ok(weather);
        }

        // POST: api/events/5/weather
        [HttpPost]
        public async Task<IActionResult> AddWeather(
        int eventId,
        WeatherSnapshot snapshot)
        {
            bool eventExists = await _context.Events
              .AnyAsync(e => e.EventId == eventId);

            if (!eventExists)
                return BadRequest("Event does not exist.");

            // Link the weather record to the selected event.
            snapshot.EventId = eventId;

            _context.WeatherSnapshots.Add(snapshot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetWeather),
              new { eventId },
              snapshot);
        }
    }
}