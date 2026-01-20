using Microsoft.AspNetCore.Mvc;

namespace TechnologySite.ViewComponents.ContactViewComponets
{
    public class _UserLayoutContactComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
