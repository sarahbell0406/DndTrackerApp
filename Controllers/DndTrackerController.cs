using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DndTrackerApp.Models;

namespace DndTrackerApp
{
    public class DndTrackerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DndTrackerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DndTracker
        // Returns a list of all DndTracker objects in the database.
        public async Task<IActionResult> Index()
        {
            return View(await _context.DndTracker.ToListAsync());
        }

        // GET: DndTracker/Details/{id}
        // Returns the details of a specific DndTracker object.
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return BadRequest();

            var dndTracker = await _context.DndTracker
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dndTracker == null)
            {
                return NotFound();
            }

            return View(dndTracker);
        }

        // GET: DndTracker/Create
        // Returns the form to create a new DndTracker object.
        public IActionResult Create()
        {
            return View();
        }

        // POST: DndTracker/Create
        // Creates a new DndTracker object in the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterName,CharacterClass,CharacterLevel,CurrentXp,ActiveCampaign,SessionOneDate,LastSessionDate,CreatedAt,UpdatedAt")] DndTracker dndTracker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dndTracker.Id = Guid.NewGuid();
                    _context.Add(dndTracker);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(dndTracker);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: DndTracker/Edit/{id}
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndTracker = await _context.DndTracker.FindAsync(id);
            if (dndTracker == null)
            {
                return NotFound();
            }
            return View(dndTracker);
        }

        // POST: DndTracker/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CharacterName,CharacterClass,CharacterLevel,CurrentXp,ActiveCampaign,SessionOneDate,LastSessionDate,CreatedAt,UpdatedAt")] DndTracker dndTracker)
        {
            if (id != dndTracker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dndTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DndTrackerExists(dndTracker.Id))
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
            return View(dndTracker);
        }

        // GET: DndTracker/Delete/{id}
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndTracker = await _context.DndTracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dndTracker == null)
            {
                return NotFound();
            }

            return View(dndTracker);
        }

        // POST: DndTracker/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dndTracker = await _context.DndTracker.FindAsync(id);
            if (dndTracker != null)
            {
                _context.DndTracker.Remove(dndTracker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DndTrackerExists(Guid id)
        {
            return _context.DndTracker.Any(e => e.Id == id);
        }
    }
}
