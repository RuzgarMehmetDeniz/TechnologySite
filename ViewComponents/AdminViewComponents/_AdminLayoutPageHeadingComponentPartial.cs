using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutPageHeadingComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
