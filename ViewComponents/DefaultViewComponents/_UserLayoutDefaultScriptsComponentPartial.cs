using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.DefaultViewComponents
{
    public class _UserLayoutDefaultScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
