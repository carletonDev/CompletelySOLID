using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Context;
using ClassLibrary.Models;
using ClassLibrary.Interfaces;

namespace CompletelySOLID.Controllers.HospitalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public RolesController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<Roles> GetRoles()
        {
            return _context.HospitalContext().Roles;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roles = await _context.HospitalContext().Roles.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles([FromRoute] int id, [FromBody] Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles.RoleId)
            {
                return BadRequest();
            }

            _context.HospitalContext().Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.HospitalContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> PostRoles([FromBody] Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HospitalContext().Roles.Add(roles);
            await _context.HospitalContext().SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.RoleId }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roles = await _context.HospitalContext().Roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.HospitalContext().Roles.Remove(roles);
            await _context.HospitalContext().SaveChangesAsync();

            return Ok(roles);
        }

        private bool RolesExists(int id)
        {
            return _context.HospitalContext().Roles.Any(e => e.RoleId == id);
        }
    }
}