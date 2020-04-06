using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _0406MVC_4.Controllers
{
    public class ControllerBase : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = ((FormsIdentity)User.Identity).Name;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}