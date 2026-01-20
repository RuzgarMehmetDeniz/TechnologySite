using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutTopNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
