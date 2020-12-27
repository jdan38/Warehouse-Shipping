using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Areas.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get 
        public async Task<IActionResult> Index()
        {

            return View(await _db.Customer.ToListAsync());
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _db.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: InventoryController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Customer.Add(customer);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);

        //}

        // GET/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _db.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //// POST/Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(int id, Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Customer.Update(customer);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        // GET/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _db.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _db.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            _db.Customer.Remove(customer);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
