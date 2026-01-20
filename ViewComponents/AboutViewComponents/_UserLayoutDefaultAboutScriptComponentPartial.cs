using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.AboutViewComponents
{
    public class _UserLayoutDefaultAboutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
