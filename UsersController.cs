using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
namespace RaceDayAPI.Controllers
{
    // Handles user profile requests.
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly RaceDayDbContext _context;
        public UsersController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        // Temporary development endpoint; restrict this in production.
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
              .Select(u => new
              {
                  u.UserId,
                  u.FirstName,
                  u.LastName,
                  u.Email,
                  u.Phone,
                  u.Role
              })
              .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users
              .Where(u => u.UserId == id)
              .Select(u => new
              {
                  u.UserId,
                  u.FirstName,
                  u.LastName,
                  u.Email,
                  u.Phone,
                  u.Role
              })
              .FirstOrDefaultAsync();

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}