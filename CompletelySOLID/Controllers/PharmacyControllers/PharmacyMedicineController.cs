using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Pharmacy;
using ClassLibrary.Interfaces;

namespace CompletelySOLID.Controllers.PharmacyControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyMedicineController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public PharmacyMedicineController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/PharmacyMedicine
        [HttpGet]
        public IEnumerable<PharmacyMedicine> GetPharmacyMedicine()
        {
            return _context.PharmacyContext().PharmacyMedicine;
        }

        // GET: api/PharmacyMedicine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacyMedicine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacyMedicine = await _context.PharmacyContext().PharmacyMedicine.FindAsync(id);

            if (pharmacyMedicine == null)
            {
                return NotFound();
            }

            return Ok(pharmacyMedicine);
        }

        // PUT: api/PharmacyMedicine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacyMedicine([FromRoute] int id, [FromBody] PharmacyMedicine pharmacyMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacyMedicine.Pmid)
            {
                return BadRequest();
            }

            _context.PharmacyContext().Entry(pharmacyMedicine).State = EntityState.Modified;

            try
            {
                await _context.PharmacyContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyMedicineExists(id))
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

        // POST: api/PharmacyMedicine
        [HttpPost]
        public async Task<IActionResult> PostPharmacyMedicine([FromBody] PharmacyMedicine pharmacyMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PharmacyContext().PharmacyMedicine.Add(pharmacyMedicine);
            await _context.PharmacyContext().SaveChangesAsync();

            return CreatedAtAction("GetPharmacyMedicine", new { id = pharmacyMedicine.Pmid }, pharmacyMedicine);
        }

        // DELETE: api/PharmacyMedicine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacyMedicine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacyMedicine = await _context.PharmacyContext().PharmacyMedicine.FindAsync(id);
            if (pharmacyMedicine == null)
            {
                return NotFound();
            }

            _context.PharmacyContext().PharmacyMedicine.Remove(pharmacyMedicine);
            await _context.PharmacyContext().SaveChangesAsync();

            return Ok(pharmacyMedicine);
        }

        private bool PharmacyMedicineExists(int id)
        {
            return _context.PharmacyContext().PharmacyMedicine.Any(e => e.Pmid == id);
        }
    }
}