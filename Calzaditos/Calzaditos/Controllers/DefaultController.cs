using Microsoft.AspNetCore.Mvc;

namespace Calzaditos.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
