using Microsoft.AspNetCore.Mvc;

namespace SSC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
