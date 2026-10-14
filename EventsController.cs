using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // This controller handles requests related to race events.
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        // This variable provides access to the database.
        private readonly RaceDayDbContext _context;
        // The constructor receives the database context.
        public EventsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/events
        // Returns all events stored in the database.
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events.ToListAsync();

            return Ok(events);
        }

        // GET: api/events/5
        // Returns one event using its ID.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var raceEvent = await _context.Events.FindAsync(id);

            if (raceEvent == null)
            {
                return NotFound();
            }

            return Ok(raceEvent);
        }

        // POST: api/events
        // Adds a new event to the database.
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] RaceEvent raceEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(raceEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetEvent),
              new { id = raceEvent.EventId },
              raceEvent);
        }

        // PUT: api/events/5
        // Updates an existing event.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEvent(
        int id,
        [FromBody] RaceEvent updatedEvent)
        {
            if (id != updatedEvent.EventId)
            {
                return BadRequest("The event IDs do not match.");
            }

            var existingEvent = await _context.Events.FindAsync(id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            // Copy the updated values onto the existing event.
            _context.Entry(existingEvent).CurrentValues.SetValues(updatedEvent);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/events/5
        // Deletes an existing event.
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var raceEvent = await _context.Events.FindAsync(id);

            if (raceEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(raceEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}