using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private readonly EntityFrameworkContext _context;

        public pedidosController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pedidos>>> Getpedidos()
        {
            return await _context.pedidos.ToListAsync();
        }

        // GET: api/pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pedidos>> Getpedidos(int id)
        {
            var pedidos = await _context.pedidos.FindAsync(id);

            if (pedidos == null)
            {
                return NotFound();
            }

            return pedidos;
        }

        // PUT: api/pedidos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpedidos(int id, pedidos pedidos)
        {
            if (id != pedidos.PedID)
            {
                return BadRequest();
            }

            _context.Entry(pedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pedidosExists(id))
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

        // POST: api/pedidos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<pedidos>> Postpedidos(pedidos pedidos)
        {
            _context.pedidos.Add(pedidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpedidos", new { id = pedidos.PedID }, pedidos);
        }

        // DELETE: api/pedidos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<pedidos>> Deletepedidos(int id)
        {
            var pedidos = await _context.pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            _context.pedidos.Remove(pedidos);
            await _context.SaveChangesAsync();

            return pedidos;
        }

        private bool pedidosExists(int id)
        {
            return _context.pedidos.Any(e => e.PedID == id);
        }
    }
}
