using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
