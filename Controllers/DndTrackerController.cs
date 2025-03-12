using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DndTrackerApp.Models;
using DndTrackerApp.ViewModels;

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
            var viewModelList = new List<DndTrackerViewModel>();
            var dndTrackerList = await _context.DndTracker.ToListAsync();
            if(dndTrackerList.Count > 0)
            {
                foreach (var dndTracker in dndTrackerList)
                {
                    viewModelList.Add(DndTrackerViewModel.ConvertToViewModel(dndTracker));
                }
            }
            return View(viewModelList);
        }

        // GET: DndTracker/Details/{id}
        // Returns the details of a specific DndTracker object.
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return View("Error", new ErrorViewModel { Message = "No ID provided." });

            try
            {
                var dndTracker = await _context.DndTracker.FirstOrDefaultAsync(m => m.Id == id);

                if (dndTracker == null)
                    return View("Error", new ErrorViewModel { Message = "No object found with that ID." });

                var viewModel = DndTrackerViewModel.ConvertToViewModel(dndTracker);

                return View(viewModel);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { 
                    Message = "An error occurred while fetching details: " + e.Message });
            }
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
        public async Task<IActionResult> Create([Bind("CharacterName,CharacterClass,CharacterLevel,CurrentXp,ActiveCampaign,SessionOneDate,LastSessionDate,CreatedAt,UpdatedAt")] DndTrackerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dndTracker = DndTrackerViewModel.ConvertToModel(viewModel);

                    dndTracker.Id = Guid.NewGuid();
                    dndTracker.CreatedAt = DateTime.Now;
                    dndTracker.UpdatedAt = DateTime.Now;
                    _context.Add(dndTracker);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { 
                    Message = "An error occurred while creating the object: " + e.Message });
            }
        }

        // GET: DndTracker/Edit/{id}
        // Returns the form to edit an existing DndTracker object.
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View("Error", new ErrorViewModel { Message = "No ID provided." });

            try 
            {
                var dndTracker = await _context.DndTracker.FindAsync(id);

                if (dndTracker == null)
                    return View("Error", new ErrorViewModel { Message = "No object found with that ID." });
                    
                var viewModel = DndTrackerViewModel.ConvertToViewModel(dndTracker);

                return View(viewModel);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { 
                    Message = "An error occurred while fetching details: " + e.Message });
            }
        }

        // POST: DndTracker/Edit/{id}
        // Edits an existing DndTracker object in the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CharacterName,CharacterClass,CharacterLevel,CurrentXp,ActiveCampaign,SessionOneDate,LastSessionDate,CreatedAt,UpdatedAt")] DndTrackerViewModel viewModel)
        {
            if (id != viewModel.Id)
                return View("Error", new ErrorViewModel { Message = "No object found with that ID." });

            if (ModelState.IsValid)
            {
                try
                {
                    var dndTracker = DndTrackerViewModel.ConvertToModel(viewModel);
                    dndTracker.UpdatedAt = DateTime.Now;

                    _context.Update(dndTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DndTrackerExists(viewModel.Id))
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
            return View(viewModel);
        }

        // GET: DndTracker/Delete/{id}
        // Returns the form to delete an existing DndTracker object.
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return View("Error", new ErrorViewModel { Message = "No object found with that ID." });

            try
            {
                var dndTracker = await _context.DndTracker.FirstOrDefaultAsync(m => m.Id == id);

                if (dndTracker == null)
                    return View("Error", new ErrorViewModel { Message = "No object found with that ID." });

                var viewModel = DndTrackerViewModel.ConvertToViewModel(dndTracker);

                return View(viewModel);

            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { 
                    Message = "An error occurred while fetching details: " + e.Message });
            }
        }

        // POST: DndTracker/Delete/{id}
        // Deletes an existing DndTracker object from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try 
            {
                var dndTracker = await _context.DndTracker.FindAsync(id);
                if (dndTracker != null)
                {
                    _context.DndTracker.Remove(dndTracker);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { 
                    Message = "An error occurred while deleting the object: " + e.Message });
            }
        }

        private bool DndTrackerExists(Guid id)
        {
            return _context.DndTracker.Any(e => e.Id == id);
        }
    }
}
