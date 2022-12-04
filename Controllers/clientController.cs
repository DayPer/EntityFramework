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
    public class clientController : ControllerBase
    {
        private readonly EntityFrameworkContext _context;

        public clientController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<client>>> Getclient()
        {
            return await _context.client.ToListAsync();
        }

        // GET: api/client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<client>> Getclient(int id)
        {
            var client = await _context.client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/client/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclient(int id, client client)
        {
            if (id != client.id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/client
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<client>> Postclient(client client)
        {
            _context.client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclient", new { id = client.id }, client);
        }

        // DELETE: api/client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<client>> Deleteclient(int id)
        {
            var client = await _context.client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.client.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        private bool clientExists(int id)
        {
            return _context.client.Any(e => e.id == id);
        }
    }
}
