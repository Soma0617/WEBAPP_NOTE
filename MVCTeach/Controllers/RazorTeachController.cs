using Microsoft.AspNetCore.Mvc;

namespace MVCTeach.Controllers
{
    public class RazorTeachController : Controller
    {
        public IActionResult Razor()
        {
            return View();
        }
    }
}
