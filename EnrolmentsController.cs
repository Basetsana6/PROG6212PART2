using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // Handles participant enrolments for race events.
    [ApiController]
    [Route("api/enrolments")]
    public class EnrolmentsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        public EnrolmentsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/enrolments
        [HttpGet]
        public async Task<IActionResult> GetEnrolments()
        {
            var enrolments = await _context.Enrolments.ToListAsync();
            return Ok(enrolments);
        }

        // GET: api/enrolments/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEnrolment(int id)
        {
            var enrolment = await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound();

            return Ok(enrolment);
        }

        // POST: api/enrolments
        [HttpPost]
        public async Task<IActionResult> CreateEnrolment(Enrolment enrolment)
        {
            // Check that the participant exists.
            bool participantExists = await _context.Users
          .AnyAsync(u => u.UserId == enrolment.ParticipantId);

            if (!participantExists)
                return BadRequest("Participant does not exist.");

            // Check that the event exists.
            bool eventExists = await _context.Events
          .AnyAsync(e => e.EventId == enrolment.EventId);

            if (!eventExists)
                return BadRequest("Event does not exist.");

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetEnrolment),
              new { id = enrolment.EnrolmentId },
              enrolment);
        }

        // DELETE: api/enrolments/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEnrolment(int id)
        {
            var enrolment = await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound();

            _context.Enrolments.Remove(enrolment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}