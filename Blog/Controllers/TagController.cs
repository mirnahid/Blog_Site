using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    
    public class TagController : Controller
    {
        // GET: Tag
        BlogContext context = new BlogContext();
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult TagWidget()
        {
            return PartialView(context.Tags.ToList());
        }
        public ActionResult ArticleList(int id)
        {
            var data = context.Articles.Where(x => x.Tags.Any(y => y.TagId == id)).ToList();
            return View("ArticleList", data);
        }
    }
}