using Microsoft.AspNetCore.Mvc;

namespace Tower_Section.Controllers
{
    public class TowerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}