using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Areas.Controllers
{
    [Area("Inventory")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public InventoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get 
        public async Task<IActionResult> Index()
        {

            return View(await _db.Inventory.ToListAsync());
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var inventory = await _db.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _db.Inventory.Add(inventory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(inventory);

        }

        // GET/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var inventory = await _db.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _db.Inventory.Update(inventory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var inventory = await _db.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _db.Inventory.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }
            _db.Inventory.Remove(inventory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
