using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Home
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult ArticleList()
        {
            var data = context.Articles.ToList();
            return View("ArticleList", data);
        }
        public PartialViewResult PopularArticlesWidget()
        {
            var model = context.Articles.OrderByDescending(x => x.UploadDate).Take(3).ToList();
            return PartialView(model);
        }
    }
}