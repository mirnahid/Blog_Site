using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    
    public class CategoryController : Controller
    {
        // GET: Category
        BlogContext context = new BlogContext();
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult CategoryWidget()
        {
            return PartialView(context.Categories.ToList());            
        }
        public ActionResult ArticleList(int id)
        {
            var data = context.Articles.Where(x => x.CategoryID == id).ToList();
            return View("ArticleList", data);
        }
    }
}