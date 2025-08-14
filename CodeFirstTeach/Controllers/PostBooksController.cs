using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstTeach.Models;

namespace CodeFirstTeach.Controllers
{
    public class PostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public PostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: PostBooks
        public async Task<IActionResult> Index()
        /*
        這叫做非同步傳輸Action : 目的是提升效率
        => 非同步傳輸跟同步傳輸差異在於非同步傳輸先完成的Action先response，但同步傳輸是等所有的Action都完成後才response
        */
        {
            /*
            筆記( 二.1.f. ) : 修改Index Action的寫法
            */
            // 寫法一 : 
            var result = _context.Books.OrderByDescending(s => s.CreatedDate);
            // 這裡的OrderByDescending是用來排序的，s => s.CreatedDate表示按照CreatedDate欄位降冪排序

            return View(await result.ToListAsync());
            /*
            寫法二 : 
            var result = await _context.Books.OrderByDescending(s => s.CreatedDate).ToListAsync();
            
            return View( result);
            */
        }

        // GET: PostBooks/Details/5
        // 筆記( 二.2.b. ) : 將PostBooksController中Details Action改名為Display( View也要改名字 )
        public async Task<IActionResult> Display(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Discription,Author,Photo,CreatedDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        private bool BookExists(string id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
