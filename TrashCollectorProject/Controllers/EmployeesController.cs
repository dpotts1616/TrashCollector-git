using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    [Authorize(Roles ="Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: List of Today's Pickups
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }

            string day = DateTime.Today.DayOfWeek.ToString();

            var exclusionList = _context.Customers.Include(e => e.ZipCode).Include(e => e.PickupDay)
                .Where(e => e.SuspendStart <= DateTime.Today && DateTime.Today <= e.SuspendEnd);

            var todaysPickups = _context.Customers.Include(e => e.ZipCode).Include(e => e.PickupDay)
                .Where(e => e.ZipCodeId == employee.ZipCodeId
                && e.PickupDay.Name == day
                || (e.ZipCodeId == employee.ZipCodeId
                && e.SpecialPickup == DateTime.Today)).Except(exclusionList);
            

            return View(await todaysPickups.ToListAsync());
        }

        //Get: Look at all pickups for specific day
        public async Task<IActionResult> Day(string day)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            

            var todaysPickups = _context.Customers.Include(e => e.ZipCode).Include(e => e.PickupDay)
               .Where(e => e.ZipCodeId == employee.ZipCodeId
               && e.PickupDay.Name == day);

            return View(await todaysPickups.ToListAsync());
        }

        //Complete Pickup for client
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CompletePickup(int? id)
        {
            var customer = _context.Customers.Where(c => c.id == id).SingleOrDefault();
            customer.Balance += 10;
            _context.Update(customer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ZipCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["ZipCodeId"] = new SelectList(_context.Set<ZipCode>(), "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ZipCodeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZipCodeId"] = new SelectList(_context.Set<ZipCode>(), "Id", "Id", employee.ZipCodeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["ZipCodeId"] = new SelectList(_context.Set<ZipCode>(), "Id", "Id", employee.ZipCodeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ZipCodeId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["ZipCodeId"] = new SelectList(_context.Set<ZipCode>(), "Id", "Id", employee.ZipCodeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ZipCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
