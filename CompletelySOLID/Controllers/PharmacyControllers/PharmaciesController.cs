using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Pharmacy;
using ClassLibrary.Interfaces;

namespace CompletelySOLID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public PharmaciesController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Pharmacies
        [HttpGet]
        public IEnumerable<Pharmacy> GetPharmacy()
        {
            return _context.PharmacyContext().Pharmacy;
        }

        // GET: api/Pharmacies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacy = await _context.PharmacyContext().Pharmacy.FindAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return Ok(pharmacy);
        }

        // PUT: api/Pharmacies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy([FromRoute] int id, [FromBody] Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacy.PharmacyId)
            {
                return BadRequest();
            }

            _context.PharmacyContext().Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.PharmacyContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
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

        // POST: api/Pharmacies
        [HttpPost]
        public async Task<IActionResult> PostPharmacy([FromBody] Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PharmacyContext().Pharmacy.Add(pharmacy);
            await _context.PharmacyContext().SaveChangesAsync();

            return CreatedAtAction("GetPharmacy", new { id = pharmacy.PharmacyId }, pharmacy);
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacy = await _context.PharmacyContext().Pharmacy.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            _context.PharmacyContext().Pharmacy.Remove(pharmacy);
            await _context.PharmacyContext().SaveChangesAsync();

            return Ok(pharmacy);
        }

        private bool PharmacyExists(int id)
        {
            return _context.PharmacyContext().Pharmacy.Any(e => e.PharmacyId == id);
        }
    }
}