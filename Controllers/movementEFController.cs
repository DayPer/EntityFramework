using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class movementEFController : Controller
    {
        private readonly EntityFrameworkContext _context;

        public movementEFController(EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: movementEF
        public async Task<IActionResult> Index()
        {
            return View(await _context.movement.ToListAsync());
        }

        // GET: movementEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _context.movement
                .FirstOrDefaultAsync(m => m.id == id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // GET: movementEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: movementEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date,clientid,account_number,account_type,movement_type,amount,balance,state,start_balance")] movement movement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movement);
        }

        // GET: movementEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _context.movement.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            return View(movement);
        }

        // POST: movementEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date,clientid,account_number,account_type,movement_type,amount,balance,state,start_balance")] movement movement)
        {
            if (id != movement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!movementExists(movement.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movement);
        }

        // GET: movementEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _context.movement
                .FirstOrDefaultAsync(m => m.id == id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // POST: movementEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movement = await _context.movement.FindAsync(id);
            _context.movement.Remove(movement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool movementExists(int id)
        {
            return _context.movement.Any(e => e.id == id);
        }
    }
}
