using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data.LibraryDBContext;

namespace LibraryManagement.Controllers
{
    public class BookReservations : Controller
    {
        private readonly LibraryDBContext _context;

        public BookReservations(LibraryDBContext context)
        {
            _context = context;
        }

        // GET: BookReservations
        public async Task<IActionResult> Index()
        {
            var libraryDBContext = _context.BookReservations.Include(b => b.Book).Include(b => b.Member);
            return View(await libraryDBContext.ToListAsync());
        }

        // GET: BookReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookReservations == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservations
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (bookReservation == null)
            {
                return NotFound();
            }

            return View(bookReservation);
        }

        // GET: BookReservations/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            return View();
        }

        // POST: BookReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,BookId,MemberId,ExpectedAvailabilityDate")] BookReservation bookReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookReservation.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", bookReservation.MemberId);
            return View(bookReservation);
        }

        // GET: BookReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookReservations == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservations.FindAsync(id);
            if (bookReservation == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookReservation.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", bookReservation.MemberId);
            return View(bookReservation);
        }

        // POST: BookReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,BookId,MemberId,ExpectedAvailabilityDate")] BookReservation bookReservation)
        {
            if (id != bookReservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookReservationExists(bookReservation.ReservationId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookReservation.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", bookReservation.MemberId);
            return View(bookReservation);
        }

        // GET: BookReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookReservations == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservations
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (bookReservation == null)
            {
                return NotFound();
            }

            return View(bookReservation);
        }

        // POST: BookReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookReservations == null)
            {
                return Problem("Entity set 'LibraryDBContext.BookReservations'  is null.");
            }
            var bookReservation = await _context.BookReservations.FindAsync(id);
            if (bookReservation != null)
            {
                _context.BookReservations.Remove(bookReservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookReservationExists(int id)
        {
            return _context.BookReservations.Any(e => e.ReservationId == id);
        }
    }
}
