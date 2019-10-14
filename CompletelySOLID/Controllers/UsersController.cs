using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Models;
using ClassLibrary.Interfaces;
using ClassLibrary;

namespace CompletelySOLID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public UsersController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
      {

            return _context.Create().Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Create().Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Create().ModifyState(users);

            try
            {
                await _context.Create().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Create().Users.Add(users);
            await _context.Create().SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Create().Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Create().Users.Remove(users);
            await _context.Create().SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Create().Users.Any(e => e.UserId == id);
        }
    }
}