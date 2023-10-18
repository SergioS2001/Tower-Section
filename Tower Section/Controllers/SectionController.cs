using Microsoft.AspNetCore.Mvc;

namespace Tower_Section.Controllers
{
    public class SectionController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}