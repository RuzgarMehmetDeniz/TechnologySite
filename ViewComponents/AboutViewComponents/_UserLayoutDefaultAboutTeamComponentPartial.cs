using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AboutViewComponents
{
    public class _UserLayoutDefaultAboutTeamComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutDefaultAboutTeamComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Contacts
                .Include(x => x.Teams)
                .ToList();

            return View(values);
        }
    }
}
