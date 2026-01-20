using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutMessagesComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutMessagesComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
    }
}
