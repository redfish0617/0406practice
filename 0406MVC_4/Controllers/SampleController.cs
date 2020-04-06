using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _0406MVC_4.Models;
using _0406MVC_4.Models.ViewModel.Sample;

namespace _0406MVC_4.Controllers
{
    public class SampleController : ControllerBase
    {
        
        private ECEntities db = new ECEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var person = db.Person.Find(model.UserID);
                if(person==null)
                {
                    ModelState.AddModelError(nameof(model.UserID), "查無此帳號");
                    return View(model);
                }
                else if(person.Password!=model.Password)
                {
                    ModelState.AddModelError(nameof(model.Password), "密碼錯誤");
                    return View(model);
                }
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(model.UserID, model.IsPersistent, 30);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                if (model.IsPersistent)
                {
                    cookie.Expires = DateTime.Now.AddDays(7);
                }
                Response.Cookies.Add(cookie);
                return Redirect(model.ReturnUrl ?? "/");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}