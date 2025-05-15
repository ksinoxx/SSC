using Microsoft.AspNetCore.Mvc;

namespace SSC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
