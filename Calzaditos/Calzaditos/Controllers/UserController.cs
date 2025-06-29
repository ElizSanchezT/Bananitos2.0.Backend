using Microsoft.AspNetCore.Mvc;

namespace Calzaditos.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
