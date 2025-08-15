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
    public class PostBooksExamController : Controller
    {
        private readonly GuestBookExamContext _context;

        public PostBooksExamController(GuestBookExamContext context)
        {
            _context = context;
        }

        // GET: PostBooksExam
        public async Task<IActionResult> Index()
        {
            var result = _context.Books.OrderByDescending(s => s.CreatedDate);
            return View(await result.ToListAsync());
        }

        // GET: PostBooksExam/Details/5
        public async Task<IActionResult> DisplayExam(string id)
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

        // GET: PostBooksExam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooksExam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Description,Photo,Author,CreatedDate")] BookExam bookExam, IFormFile? newPhoto)
        {
            bookExam.CreatedDate = DateTime.Now;

            if (newPhoto != null && newPhoto.Length != 0)
            {
                if (newPhoto.ContentType != "image/jpeg" && newPhoto.ContentType != "image/png")
                {
                    ViewData["ErrorMessage"] = "上傳的檔案格式不正確，請上傳JPG或PNG格式的圖片";
                    return View();
                }
                string fileName = bookExam.BookID + Path.GetExtension(newPhoto.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookExamPhotos", fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    newPhoto.CopyTo(fs);
                }
                bookExam.Photo = fileName; 
            }

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
