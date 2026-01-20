using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;

namespace TechnologySite.Controllers
{
    public class TeamController : Controller
    {
        private readonly TechnologyContext _context;

        public TeamController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var value = _context.Teams.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTeam(int id)
        {
            var values = _context.Teams.Find(id);
            _context.Teams.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult TeamIndex()
        {
            var contact = _context.Contacts
                 .Include(a => a.Teams)
                 .ToList();

            return View(contact);
        }
    }
}
