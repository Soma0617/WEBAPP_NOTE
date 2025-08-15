using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstTeach.Models;
using Microsoft.EntityFrameworkCore.Migrations;

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
        public async Task<IActionResult> Create([Bind("BookID,Title,Discription,Author,Photo,CreatedDate")] Book book, IFormFile? newPhoto)
        {
            // book.BookID = Guid.NewGuid().ToString(); => 產生一個新的GUID作為BookID，這個東西也可以寫在View中BookID的<input>裡
            book.CreatedDate = DateTime.Now; // 設定CreatedDate為目前時間

            // 筆記( 二.4.f. ) : 修改Post Create Action，加上處理上傳照片的功能
            if (newPhoto != null && newPhoto.Length != 0)
            {
                // 1. 只允許上傳圖片 : 
                if (newPhoto.ContentType != "image/jpeg" && newPhoto.ContentType != "image/png")
                {
                    ViewData["ErrorMessage"] = "上傳的檔案格式不正確，請上傳JPG或PNG格式的圖片";
                    return View();
                }
                // 2. 取得檔案名稱 : 
                string fileName = book.BookID + Path.GetExtension(newPhoto.FileName);
                // 3. 取得檔案完整位置 : 
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookPhotos", fileName);
                // 4. 將檔案上傳並存取於指定路徑 : 
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    newPhoto.CopyTo(fs);
                }
                book.Photo = fileName; // 將檔案名稱存入Book的Photo屬性
            }

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
