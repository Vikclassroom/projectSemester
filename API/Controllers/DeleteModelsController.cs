using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    public class DeleteModelsController : Controller
    {
        private readonly APIContext _context;

        public DeleteModelsController(APIContext context)
        {
            _context = context;
        }

        // GET: DeleteModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeleteModel.ToListAsync());
        }

        // GET: DeleteModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = await _context.DeleteModel
                .FirstOrDefaultAsync(m => m.DeleteId == id);
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }

        // GET: DeleteModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeleteModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeleteId,AccountId,Date")] DeleteModel deleteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deleteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deleteModel);
        }

        // GET: DeleteModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = await _context.DeleteModel.FindAsync(id);
            if (deleteModel == null)
            {
                return NotFound();
            }
            return View(deleteModel);
        }

        // POST: DeleteModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeleteId,AccountId,Date")] DeleteModel deleteModel)
        {
            if (id != deleteModel.DeleteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deleteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeleteModelExists(deleteModel.DeleteId))
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
            return View(deleteModel);
        }

        // GET: DeleteModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = await _context.DeleteModel
                .FirstOrDefaultAsync(m => m.DeleteId == id);
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }

        // POST: DeleteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteModel = await _context.DeleteModel.FindAsync(id);
            _context.DeleteModel.Remove(deleteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeleteModelExists(int id)
        {
            return _context.DeleteModel.Any(e => e.DeleteId == id);
        }
    }
}
