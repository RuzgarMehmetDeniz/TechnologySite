using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;

namespace TechnologySite.Controllers
{
    public class CommentsController : Controller
    {
        private readonly TechnologyContext _context;

        public CommentsController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult CommentsList()
        {
            var commentlist = _context.Contacts.ToList();
            return View(commentlist);
        }
        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComment(Contact contact)
        {
            contact.CreateDate = DateTime.Now;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("CommentsList");
        }

        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateComment(Contact contact)
        {
            contact.CreateDate = DateTime.Now;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("CommentsList");
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CommentsList");
        }
        public IActionResult CommentIndex()
        {
            var contact = _context.Contacts
                .Include(a => a.Teams)
                .ToList();

            return View(contact);
        }
    }
}
