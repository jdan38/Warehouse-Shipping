using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Areas.Controllers
{
    [Area("Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get 
        public async Task<IActionResult> Index()
        {

            return View(await _db.Employees.ToListAsync());
        }

       // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
           
        }

        // GET/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var employee = await _db.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var employee = await _db.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _db.Employees.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
