using Microsoft.AspNetCore.Mvc;

namespace CabManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
