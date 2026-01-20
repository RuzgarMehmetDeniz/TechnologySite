using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutUserComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
