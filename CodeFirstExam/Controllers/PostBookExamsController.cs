using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstExam.Models;

namespace CodeFirstExam.Controllers
{
    public class PostBookExamsController : Controller
    {
        private readonly GuestBookExamContext _context;

        public PostBookExamsController(GuestBookExamContext context)
        {
            _context = context;
        }

        // GET: PostBookExams
        public async Task<IActionResult> Index()
        {
            var result = _context.Books.OrderByDescending(s => s.CreatedDate);

            return View(await result.ToListAsync());
        }

        // GET: PostBookExams/Details/5
        public async Task<IActionResult> Display(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookExam = await _context.Books
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookExam == null)
            {
                return NotFound();
            }

            return View(bookExam);
        }

        // GET: PostBookExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBookExams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Discription,Photo,Author,CreatedDate")] BookExam bookExam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookExam);
        }
        private bool BookExamExists(string id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
