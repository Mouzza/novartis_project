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

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

         public ApplicationRoleManager roleManager; 
         public ApplicationRoleManager RoleManager 
        { 
            get 
            { 
                return this.roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); 
            } 
            private set { this.roleManager = value; } 
        }

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


    
         // /Admin/Roles
        public ActionResult Roles()
        {
            var roles = apc.Roles.ToList();
            return View(roles);
            
        }

        // GET: Admin 
        public ActionResult Index()
        {
            ModelState.Clear();
            return View();
            
        }


        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
