using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Newtonsoft.Json.Linq;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }

            customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.PickupDay)
                .Include(c => c.ZipCode)
                .FirstOrDefaultAsync(m => m.id == customer.id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["PickupDayId"] = new SelectList(_context.Days, "Id", "Name");
            ViewData["ZipCodeId"] = new SelectList(_context.ZipCodes, "Id", "Code");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Address,City,State,IdentityUserId,ZipCodeId,PickupDayId,SpecialPickup,SuspendStart,SuspendEnd,Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;

                string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.Address}+{customer.City}+{customer.State}+&key={APIKeys.GOOGLE_API_KEY}";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonResult = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(jsonResult);
                customer.Latitude = (double)jObject["results"][0]["geometry"]["location"]["lat"];
                customer.Longitude = (double)jObject["results"][0]["geometry"]["location"]["lng"];

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PickupDayId"] = new SelectList(_context.Days, "Id", "Name", customer.PickupDayId);
            ViewData["ZipCodeId"] = new SelectList(_context.ZipCodes, "Id", "Code", customer.ZipCodeId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["PickupDayId"] = new SelectList(_context.Days, "Id", "Name", customer.PickupDayId);
            ViewData["ZipCodeId"] = new SelectList(_context.ZipCodes, "Id", "Code", customer.ZipCodeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Address,City,State,IdentityUserId,ZipCodeId,PickupDayId,SpecialPickup,SuspendStart,SuspendEnd,Balance")] Customer customer)
        {
            if (id != customer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.id))
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
            ViewData["PickupDayId"] = new SelectList(_context.Days, "Id", "Name", customer.PickupDayId);
            ViewData["ZipCodeId"] = new SelectList(_context.ZipCodes, "Id", "Code", customer.ZipCodeId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.PickupDay)
                .Include(c => c.ZipCode)
                .FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.id == id);
        }
    }
}
