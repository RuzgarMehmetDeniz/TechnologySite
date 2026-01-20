using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
