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
    public class ListModelsController : Controller
    {
        private readonly APIContext _context;

        public ListModelsController(APIContext context)
        {
            _context = context;
        }

        // GET: ListModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListModel.ToListAsync());
        }

        // GET: ListModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel
                .FirstOrDefaultAsync(m => m.ListId == id);
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        // GET: ListModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListId,Title,Band,Album")] ListModel listModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listModel);
        }

        // GET: ListModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel.FindAsync(id);
            if (listModel == null)
            {
                return NotFound();
            }
            return View(listModel);
        }

        // POST: ListModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListId,Title,Band,Album")] ListModel listModel)
        {
            if (id != listModel.ListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListModelExists(listModel.ListId))
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
            return View(listModel);
        }

        // GET: ListModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel
                .FirstOrDefaultAsync(m => m.ListId == id);
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        // POST: ListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listModel = await _context.ListModel.FindAsync(id);
            _context.ListModel.Remove(listModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListModelExists(int id)
        {
            return _context.ListModel.Any(e => e.ListId == id);
        }
    }
}
