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
    public class HospitalsController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public HospitalsController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Hospitals
        [HttpGet]
        public IEnumerable<Hospital> GetHospital()
        {
            return _context.HospitalContext().Hospital;
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospital([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hospital = await _context.HospitalContext().Hospital.FindAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        // PUT: api/Hospitals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospital([FromRoute] int id, [FromBody] Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospital.HospitalID)
            {
                return BadRequest();
            }

            _context.HospitalContext().Entry(hospital).State = EntityState.Modified;

            try
            {
                await _context.HospitalContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // POST: api/Hospitals
        [HttpPost]
        public async Task<IActionResult> PostHospital([FromBody] Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HospitalContext().Hospital.Add(hospital);
            await _context.HospitalContext().SaveChangesAsync();

            return CreatedAtAction("GetHospital", new { id = hospital.HospitalID }, hospital);
        }

        // DELETE: api/Hospitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hospital = await _context.HospitalContext().Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _context.HospitalContext().Hospital.Remove(hospital);
            await _context.HospitalContext().SaveChangesAsync();

            return Ok(hospital);
        }

        private bool HospitalExists(int id)
        {
            return _context.HospitalContext().Hospital.Any(e => e.HospitalID == id);
        }
    }
}