using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        private readonly EntityFrameworkContext _context;

        public accountController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<account>>> Getaccount()
        {
            return await _context.account.ToListAsync();
        }

        // GET: api/account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<account>> Getaccount(int id)
        {
            var account = await _context.account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccount(int id, account account)
        {
            if (id != account.id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountExists(id))
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

        // POST: api/account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<account>> Postaccount(account account)
        {
            _context.account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaccount", new { id = account.id }, account);
        }

        // DELETE: api/account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<account>> Deleteaccount(int id)
        {
            var account = await _context.account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.account.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        private bool accountExists(int id)
        {
            return _context.account.Any(e => e.id == id);
        }
    }
}
