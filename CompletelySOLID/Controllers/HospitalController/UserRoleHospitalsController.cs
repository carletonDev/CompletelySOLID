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
    [Route("api/urh")]
    [ApiController]
    public class UserRoleHospitalsController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public UserRoleHospitalsController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/UserRoleHospitals
        [HttpGet]
        public IEnumerable<UserRoleHospital> GetUserRoleHospital()
        {
            return _context.HospitalContext().UserRoleHospital;
        }

        // GET: api/UserRoleHospitals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRoleHospital([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRoleHospital = await _context.HospitalContext().UserRoleHospital.FindAsync(id);

            if (userRoleHospital == null)
            {
                return NotFound();
            }

            return Ok(userRoleHospital);
        }

        // PUT: api/UserRoleHospitals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoleHospital([FromRoute] int id, [FromBody] UserRoleHospital userRoleHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRoleHospital.urhid)
            {
                return BadRequest();
            }

            _context.HospitalContext().Entry(userRoleHospital).State = EntityState.Modified;

            try
            {
                await _context.HospitalContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleHospitalExists(id))
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
        /// <summary>
        /// finds a user and whether they have been a patient doctor or admin  at any particular hospital
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet("{firstName}/{lastName}/{roleType}/{hosptialName}")]
        public IEnumerable<UserRoleHospital> FindUserRoleHospital([FromRoute] string firstName,string lastName,string roleType,string hosptialName)
        {
            return _context.HospitalContext().UserRoleHospital.Where(m => m.Users.FirstName == firstName && m.Users.LastName == lastName && m.Role.RoleType == roleType && m.Hospital.HospitalName == hosptialName);
        }
        // POST: api/UserRoleHospitals
        [HttpPost]
        public async Task<IActionResult> PostUserRoleHospital([FromBody] UserRoleHospital userRoleHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HospitalContext().UserRoleHospital.Add(userRoleHospital);
            await _context.HospitalContext().SaveChangesAsync();

            return CreatedAtAction("GetUserRoleHospital", new { id = userRoleHospital.urhid }, userRoleHospital);
        }

        // DELETE: api/UserRoleHospitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoleHospital([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRoleHospital = await _context.HospitalContext().UserRoleHospital.FindAsync(id);
            if (userRoleHospital == null)
            {
                return NotFound();
            }

            _context.HospitalContext().UserRoleHospital.Remove(userRoleHospital);
            await _context.HospitalContext().SaveChangesAsync();

            return Ok(userRoleHospital);
        }

        private bool UserRoleHospitalExists(int id)
        {
            return _context.HospitalContext().UserRoleHospital.Any(e => e.urhid == id);
        }
    }
}