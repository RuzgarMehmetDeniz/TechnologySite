using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AboutViewComponents
{
    public class _UserLayoutDefaultAboutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
