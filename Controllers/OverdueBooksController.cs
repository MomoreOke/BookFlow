using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data.LibraryDBContext;
using LibraryManagement.Service;

namespace LibraryManagement.Controllers
{
    public class OverdueBooksController : Controller
    {
        private readonly LibraryDBContext _context;
        private OverdueService _overdueService;

        public OverdueBooksController(LibraryDBContext context, OverdueService overdueService)
        {
            _context = context;
            _overdueService = overdueService;
        }

        // GET: OverdueBooks
        public async Task<IActionResult> Index()
        {

            if (_overdueService.AddOverDueBooks() == true)
            {
                var libraryDBContext = _context.OverdueBooks.Include(o => o.Book).Include(o => o.Member);
                return View(await libraryDBContext.ToListAsync());
            }
            return View();
        }

        // GET: OverdueBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OverdueBooks == null)
            {
                return NotFound();
            }

            var overdueBook = await _context.OverdueBooks
                .Include(o => o.Book)
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.OverdueBookId == id);
            if (overdueBook == null)
            {
                return NotFound();
            }

            return View(overdueBook);
        }

        // GET: OverdueBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "UserAddress");
            return View();
        }

        // POST: OverdueBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OverdueBookId,NumberOfDaysOverdue,FineAmount,BorrowerName,MemberId,BookId")] OverdueBook overdueBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(overdueBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName", overdueBook.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "UserAddress", overdueBook.MemberId);
            return View(overdueBook);
        }

        // GET: OverdueBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OverdueBooks == null)
            {
                return NotFound();
            }

            var overdueBook = await _context.OverdueBooks.FindAsync(id);
            if (overdueBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName", overdueBook.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "UserAddress", overdueBook.MemberId);
            return View(overdueBook);
        }

        // POST: OverdueBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OverdueBookId,NumberOfDaysOverdue,FineAmount,BorrowerName,MemberId,BookId")] OverdueBook overdueBook)
        {
            if (id != overdueBook.OverdueBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(overdueBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OverdueBookExists(overdueBook.OverdueBookId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName", overdueBook.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "UserAddress", overdueBook.MemberId);
            return View(overdueBook);
        }

        // GET: OverdueBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OverdueBooks == null)
            {
                return NotFound();
            }

            var overdueBook = await _context.OverdueBooks
                .Include(o => o.Book)
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.OverdueBookId == id);
            if (overdueBook == null)
            {
                return NotFound();
            }

            return View(overdueBook);
        }

        // POST: OverdueBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OverdueBooks == null)
            {
                return Problem("Entity set 'LibraryDBContext.OverdueBooks'  is null.");
            }
            var overdueBook = await _context.OverdueBooks.FindAsync(id);
            if (overdueBook != null)
            {
                _context.OverdueBooks.Remove(overdueBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OverdueBookExists(int id)
        {
          return _context.OverdueBooks.Any(e => e.OverdueBookId == id);
        }
    }
}
