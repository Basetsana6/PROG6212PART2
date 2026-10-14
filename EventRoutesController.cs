using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // Provides route information for race events.
    [ApiController]
    [Route("api/events/{eventId}/route")]
    public class EventRoutesController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        public EventRoutesController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/events/5/route
        [HttpGet]
        public async Task<IActionResult> GetRoute(int eventId)
        {
            // Find the route connected to the requested event.
            var route = await _context.EventRoutes
          .FirstOrDefaultAsync(r => r.EventId == eventId);

            if (route == null)
                return NotFound("No route was found for this event.");

            return Ok(route);
        }

        // POST: api/events/5/route
        [HttpPost]
        public async Task<IActionResult> CreateRoute(
        int eventId,
        EventRoute route)
        {
            bool eventExists = await _context.Events
              .AnyAsync(e => e.EventId == eventId);

            if (!eventExists)
                return BadRequest("Event does not exist.");

            // Ensure the route belongs to the event in the URL.
            route.EventId = eventId;

            _context.EventRoutes.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetRoute),
              new { eventId },
              route);
        }
    }
}