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
    public class BillsController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public BillsController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public IEnumerable<Bills> GetBills()
        {
            return _context.HospitalContext().Bills;
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bills = await _context.HospitalContext().Bills.FindAsync(id);

            if (bills == null)
            {
                return NotFound();
            }

            return Ok(bills);
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills([FromRoute] int id, [FromBody] Bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bills.BillID)
            {
                return BadRequest();
            }

            _context.HospitalContext().Entry(bills).State = EntityState.Modified;

            try
            {
                await _context.HospitalContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillsExists(id))
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

        // POST: api/Bills
        [HttpPost]
        public async Task<IActionResult> PostBills([FromBody] Bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HospitalContext().Bills.Add(bills);
            await _context.HospitalContext().SaveChangesAsync();

            return CreatedAtAction("GetBills", new { id = bills.BillID }, bills);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bills = await _context.HospitalContext().Bills.FindAsync(id);
            if (bills == null)
            {
                return NotFound();
            }

            _context.HospitalContext().Bills.Remove(bills);
            await _context.HospitalContext().SaveChangesAsync();

            return Ok(bills);
        }

        private bool BillsExists(int id)
        {
            return _context.HospitalContext().Bills.Any(e => e.BillID == id);
        }
    }
}