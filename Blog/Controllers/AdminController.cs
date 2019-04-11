using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AuthorApprovals()
        {
            var data = context.Nahids.Where(x => x.Author == true && x.Approved == false).ToList();
            return View(data);
        }
        public ActionResult Approved(int id)
        {
           Nahid usr = context.Nahids.FirstOrDefault(x => x.UserId == id);
            usr.Approved = true;
            context.SaveChanges();
            return RedirectToAction("AuthorApprovals");
        }
    }
}