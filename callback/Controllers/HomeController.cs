using Microsoft.AspNetCore.Mvc;

namespace callback.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}