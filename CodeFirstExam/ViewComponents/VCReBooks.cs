using CodeFirstExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstExam.ViewComponents
{
    public class VCReBooks : ViewComponent
    {
        private readonly GuestBookExamContext _context;

        public VCReBooks(GuestBookExamContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string bookID)
        {
            var rebook = await _context.ReBooks.Where(r => r.BookID == bookID).OrderByDescending(r => r.CreatedDate).ToListAsync();

            return View(rebook);
        }
    }
}
