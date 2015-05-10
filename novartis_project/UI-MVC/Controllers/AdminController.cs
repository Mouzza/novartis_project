using JPP.UI.Web.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.ObjectModel;

namespace JPP.UI.Web.MVC.Controllers
{
     [CustomAuthorizeAttribute(Roles = "Admin")]
    public class AdminController : Controller
    {

        

        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {

            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                    return;
                }

                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result = new RedirectResult("~/Account/AccessDenied");
                    return;
                }
            }
        }


  
        private ApplicationDbContext apc = new ApplicationDbContext();
         
         // /Admin/Error
        public ActionResult Error()
        {
            return View();
        }


    
       

        // GET: Admin 
        public ActionResult Index()
        {
            ModelState.Clear();
            return View();
            
        }

        public ActionResult Menu()
        {
     
            return View();

        }


   
      
    }
}
