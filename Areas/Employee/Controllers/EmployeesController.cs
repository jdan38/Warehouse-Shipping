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

            return View(await _db.Employee.ToListAsync());
        }

       // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _db.Category.FindAsync(id);
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
                _db.Employee.Add(employee);
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
            var employee = await _db.Employee.FindAsync(id);
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
                _db.Employee.Update(employee);
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
            var employee = await _db.Employee.FindAsync(id);
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
            var category = await _db.Category.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
