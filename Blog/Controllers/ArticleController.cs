using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using Blog.App_Classes;

namespace Blog.Controllers
{
    using System;
    using System.Drawing;
    [Authorize]
    public class ArticleController : Controller
    {
        // GET: Article
        BlogContext context = new BlogContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var data = context.Articles.FirstOrDefault(x => x.ArticleId == id);
            
            return View(data);
        }
        [Authorize(Roles ="Admin,Author")]
        public ActionResult AddArticle()
        {
            ViewBag.Category = context.Categories.ToList();
            return View();
        }
        [Authorize(Roles = "Admin,Author")]
        [HttpPost]
        public ActionResult AddArticle(Article arcl, HttpPostedFileBase image)
        {
            Image img = Image.FromStream(image.InputStream);
            Bitmap smlImage = new Bitmap(img, Settings.ImgSmall);
            Bitmap mdlImage = new Bitmap(img, Settings.ImgMedium);
            Bitmap bigImage = new Bitmap(img, Settings.ImgLarge);
            smlImage.Save(Server.MapPath("/Content/ArticleImage/Small"+image.FileName));
            mdlImage.Save(Server.MapPath("/Content/ArticleImage/Midle"+image.FileName));
            bigImage.Save(Server.MapPath("/Content/ArticleImage/Big"+image.FileName));
            Imagee skl = new Imagee();
            skl.Small = "/Content/ArticleImage/Small" + image.FileName;
            skl.Middle = "/Content/ArticleImage/Midle" + image.FileName;
            skl.Big = "/Content/ArticleImage/Big" + image.FileName;
            context.Imagees.Add(skl);
            context.SaveChanges();
            arcl.ImageID = skl.ImageId;
            arcl.UploadDate = DateTime.Now;
            arcl.Views = 0;
            arcl.Like = 0;
            int autId = context.Nahids.First(x => x.UserName == User.Identity.Name).UserId;
            arcl.AuthorID = autId;
            context.Articles.Add(arcl);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public string Like(int id)
        {
            Article arcl = context.Articles.FirstOrDefault(x => x.ArticleId == id);
            arcl.Like++;
            context.SaveChanges();
            return arcl.Like.ToString();
        }
    }
}