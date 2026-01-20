using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutTeamComponentPartial:ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutTeamComponentPartial(TechnologyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values =_context.Teams.ToList();
            return View(values);
        }
    }
}
