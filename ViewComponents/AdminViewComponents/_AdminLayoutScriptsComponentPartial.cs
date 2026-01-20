using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
