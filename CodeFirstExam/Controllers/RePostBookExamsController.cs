using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstExam.Models;

namespace CodeFirstExam.Controllers
{
    public class RePostBookExamsController : Controller
    {
        private readonly GuestBookExamContext _context;

        public RePostBookExamsController(GuestBookExamContext context)
        {
            _context = context;
        }
        // GET: RePostBookExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RePostBookExams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReBookID,Description,Author,CreatedDate,BookID")] ReBookExam reBookExam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reBookExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reBookExam);
        }
    }
}
