using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Controllers
{
   
    public class UsersController : Controller
    {
        BlogContext context = new BlogContext();
        // GET: Users
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Nahid usr)
        {
            string ka = ValidateUser(usr.UserName, usr.Password);
            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,usr.UserName,DateTime.Now,DateTime.Now.AddMinutes(15),true,ka,FormsAuthentication.FormsCookiePath);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
               
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(usr.UserName, true);
            }
            return RedirectToAction("Index", "Home");
        }
        string ValidateUser(string nn,string pwd)
        {
            Nahid usr = context.Nahids.FirstOrDefault(x => x.UserName == nn && x.Password == pwd);
            if (usr!=null)
            {
                return usr.UserName;
            }
            else
            {
                return "";
            }
            
        }
        public ActionResult LogOut(string redirectUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(redirectUrl);
        }
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Nahid usr ,string rdMale,string rdFemale)
        {
            if (!string.IsNullOrEmpty(rdMale))
            {
                usr.Gender = true;
            }
            if (!string.IsNullOrEmpty(rdFemale))
            {
                usr.Gender = false;
            }
            usr.Author = true;
            usr.Approved = false;
            usr.Online = true;
            usr.RegistrationDate = DateTime.Now;
            context.Nahids.Add(usr);
            context.SaveChanges();
            return RedirectToAction("SignIn");
        }
        public ActionResult DaxilOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DaxilOl(Nahid nhd)
        {
            context.Nahids.Add(nhd);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
    }
}