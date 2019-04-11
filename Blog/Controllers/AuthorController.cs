using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    
    public class AuthorController : Controller
    {
       
        // GET: Author
        BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Writer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Writer(Nahid usr, string rdMale,string rdFemale)
        {
            if (!string.IsNullOrEmpty(rdMale))
            {
                usr.Gender = true;
            }
            if (!string.IsNullOrEmpty(rdFemale))
            {
                usr.Gender = false;
            }
            usr.DateofBrith = DateTime.Now;
            usr.Author = true;
            usr.Online = true;
            usr.Approved = true;            
            context.Nahids.Add(usr);
            context.SaveChanges();
            Role author = context.Roles.FirstOrDefault(x => x.RoleName == "Author");
            UserRole usrl = new UserRole();
            usrl.UserRoleId = author.RoleId;
            usrl.UserID = usr.UserId;
            context.UserRoles.Add(usrl);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
           
        }
    }
}