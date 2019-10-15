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
    public class TransactionsController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public TransactionsController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transactions> GetTransactions()
        {
            return _context.PharmacyContext().Transactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactions = await _context.PharmacyContext().Transactions.FindAsync(id);

            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactions([FromRoute] int id, [FromBody] Transactions transactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactions.TransactionId)
            {
                return BadRequest();
            }

            _context.PharmacyContext().Entry(transactions).State = EntityState.Modified;

            try
            {
                await _context.PharmacyContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsExists(id))
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

        // POST: api/Transactions
        [HttpPost]
        public async Task<IActionResult> PostTransactions([FromBody] Transactions transactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PharmacyContext().Transactions.Add(transactions);
            await _context.PharmacyContext().SaveChangesAsync();

            return CreatedAtAction("GetTransactions", new { id = transactions.TransactionId }, transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactions = await _context.PharmacyContext().Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            _context.PharmacyContext().Transactions.Remove(transactions);
            await _context.PharmacyContext().SaveChangesAsync();

            return Ok(transactions);
        }

        private bool TransactionsExists(int id)
        {
            return _context.PharmacyContext().Transactions.Any(e => e.TransactionId == id);
        }
    }
}