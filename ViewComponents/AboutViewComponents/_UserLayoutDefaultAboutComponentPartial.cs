using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AboutViewComponents
{
    public class _UserLayoutDefaultAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
