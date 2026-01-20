using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutAlertsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
