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
    public class movementController : ControllerBase
    {
        private readonly EntityFrameworkContext _context;

        public movementController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/movement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<movement>>> Getmovement()
        {
            return await _context.movement.ToListAsync();
        }

        // GET: api/movement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<movement>> Getmovement(int id)
        {
            var movement = await _context.movement.FindAsync(id);

            if (movement == null)
            {
                return NotFound();
            }

            return movement;
        }

        // PUT: api/movement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmovement(int id, movement movement)
        {
            if (id != movement.id)
            {
                return BadRequest();
            }

            _context.Entry(movement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!movementExists(id))
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

        // POST: api/movement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<movement>> Postmovement(movement movement)
        {
            _context.movement.Add(movement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmovement", new { id = movement.id }, movement);
        }

        // DELETE: api/movement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<movement>> Deletemovement(int id)
        {
            var movement = await _context.movement.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            _context.movement.Remove(movement);
            await _context.SaveChangesAsync();

            return movement;
        }

        private bool movementExists(int id)
        {
            return _context.movement.Any(e => e.id == id);
        }
    }
}
