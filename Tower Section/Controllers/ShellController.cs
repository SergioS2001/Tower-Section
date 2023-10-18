using Microsoft.AspNetCore.Mvc;

namespace Tower_Section.Controllers
{
    public class ShellController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}