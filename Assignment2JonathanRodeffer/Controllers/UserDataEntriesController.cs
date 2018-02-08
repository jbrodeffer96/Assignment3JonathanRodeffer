using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2JonathanRodeffer.Models;

namespace Assignment2JonathanRodeffer.Controllers
{
    public class UserDataEntriesController : Controller
    {
        private readonly Assignment2JonathanRodefferContext _context;

        public UserDataEntriesController(Assignment2JonathanRodefferContext context)
        {
            _context = context;
        }

        // GET: UserDataEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserDataEntry.ToListAsync());
        }

        // GET: UserDataEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataEntry = await _context.UserDataEntry
                .SingleOrDefaultAsync(m => m.id == id);
            if (userDataEntry == null)
            {
                return NotFound();
            }

            return View(userDataEntry);
        }

        // GET: UserDataEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDataEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailAddress,Message,Confirm")] UserDataEntry userDataEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDataEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDataEntry);
        }

        // GET: UserDataEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataEntry = await _context.UserDataEntry.SingleOrDefaultAsync(m => m.id == id);
            if (userDataEntry == null)
            {
                return NotFound();
            }
            return View(userDataEntry);
        }

        // POST: UserDataEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailAddress,Message,Confirm")] UserDataEntry userDataEntry)
        {
            if (id != userDataEntry.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDataEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataEntryExists(userDataEntry.id))
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
            return View(userDataEntry);
        }

        // GET: UserDataEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataEntry = await _context.UserDataEntry
                .SingleOrDefaultAsync(m => m.id == id);
            if (userDataEntry == null)
            {
                return NotFound();
            }

            return View(userDataEntry);
        }

        // POST: UserDataEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDataEntry = await _context.UserDataEntry.SingleOrDefaultAsync(m => m.id == id);
            _context.UserDataEntry.Remove(userDataEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataEntryExists(int id)
        {
            return _context.UserDataEntry.Any(e => e.id == id);
        }
    }
}
