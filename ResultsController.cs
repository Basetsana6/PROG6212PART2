using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // Handles race result requests.
    [ApiController]
    [Route("api/results")]
    public class ResultsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        public ResultsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/results
        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = await _context.Results.ToListAsync();
            return Ok(results);
        }

        // GET: api/results/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/results
        [HttpPost]
        public async Task<IActionResult> CreateResult(RaceResult result)
        {
            // Check that the enrolment exists before recording a result.
            bool enrolmentExists = await _context.Enrolments
          .AnyAsync(e => e.EnrolmentId == result.EnrolmentId);

            if (!enrolmentExists)
                return BadRequest("Enrolment does not exist.");

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetResult),
              new { id = result.ResultId },
              result);
        }

        // DELETE: api/results/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
                return NotFound();

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}