using CodeFirstTeach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTeach.ViewComponents
{
    /*
    筆記( 二.3.c. ) : VCReBooks class繼承ViewComponent( 注意using Microsoft.AspNetCore.Mvc; )
    */
    public class VCReBooks : ViewComponent
    {
        private readonly GuestBookContext _context;

        public VCReBooks(GuestBookContext context)
        {
            _context = context;
        }

        /*
        筆記( 二.3.d. ) : 撰寫InvokeAsync()方法取得回覆留言資料
        */
        public async Task<IViewComponentResult> InvokeAsync(string bookID)
        {
            var rebook = await _context.ReBooks.Where(r=>r.BookID == bookID).OrderByDescending(r=>r.CreatedDate).ToListAsync();

            return View(rebook);
        }
    }
}
