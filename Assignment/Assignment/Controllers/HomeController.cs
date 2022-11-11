using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(EventArgs e)
        {
            
            return View("Index", "Layout");
        }
    }
}
