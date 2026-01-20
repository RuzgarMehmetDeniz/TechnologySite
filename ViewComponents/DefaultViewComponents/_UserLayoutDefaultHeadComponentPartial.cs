using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.DefaultViewComponents
{
    public class _UserLayoutDefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
