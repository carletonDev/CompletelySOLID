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
    public class MedicineController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public MedicineController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Medicine
        [HttpGet]
        public IEnumerable<Medicine> GetMedicine()
        {
            return _context.PharmacyContext().Medicine;
        }

        // GET: api/Medicine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicine = await _context.PharmacyContext().Medicine.FindAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/Medicine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine([FromRoute] int id, [FromBody] Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }

            _context.PharmacyContext().Entry(medicine).State = EntityState.Modified;

            try
            {
                await _context.PharmacyContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
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

        // POST: api/Medicine
        [HttpPost]
        public async Task<IActionResult> PostMedicine([FromBody] Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PharmacyContext().Medicine.Add(medicine);
            await _context.PharmacyContext().SaveChangesAsync();

            return CreatedAtAction("GetMedicine", new { id = medicine.MedicineId }, medicine);
        }

        // DELETE: api/Medicine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicine = await _context.PharmacyContext().Medicine.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.PharmacyContext().Medicine.Remove(medicine);
            await _context.PharmacyContext().SaveChangesAsync();

            return Ok(medicine);
        }

        private bool MedicineExists(int id)
        {
            return _context.PharmacyContext().Medicine.Any(e => e.MedicineId == id);
        }
    }
}