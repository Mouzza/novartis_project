using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using JPP.UI.Web.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Drawing;

using System.IO;


namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidAccountController : ApiController
    {
        //public ApplicationRoleManager roleManager;
        //public ApplicationRoleManager RoleManager
        //{
        //    get
        //    {
        //        return this.roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        //    }
        //    private set { this.roleManager = value; }
        //}
        //private ApplicationUserManager _userManager;
        //public AndroidAccountController()
        //{
        //}
        //public AndroidAccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //private ApplicationSignInManager _signInManager;
        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set { _signInManager = value; }
        //}

        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User
        //        {
        //            UserName = model.Name,
        //            Email = model.Email,
        //            Created = DateTime.Now,
        //            profilePublic = true,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Birthday = model.Birthday,
        //            Zipcode = model.Zipcode
        //        };

        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            //Geef "Gebruiker" role aan user
        //            var role = RoleManager.FindByName("Gebruiker");

        //            if (user != null) UserManager.AddToRole(user.Id, role.Name);


                    
        //        }
              
        //    }


        //    return (model);
        //}

    }
}
