using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public ApplicationRoleManager roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return this.roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set { this.roleManager = value; }
        }
        private ApplicationUserManager _userManager;
        public AndroidAccountController()
        {
        }
        public AndroidAccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }
        [HttpGet]
        [ActionName("Register")]
        public async Task<IHttpActionResult> Register(AndroidGebruiker model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.gebruikersnaam,
                    Email = model.email,
                    Created = DateTime.Now,
                    profilePublic = true,
                    FirstName = model.voornaam,
                    LastName = model.achternaam,
                    Birthday = model.geboorteDatum,
                    Zipcode = model.postcode,
                    PhoneNumber = model.telefoonnummer
                };
                var result = await UserManager.CreateAsync(user, model.wachtwoord);
                if (result.Succeeded)
                {
                    var role = RoleManager.FindByName("Gebruiker");

                    if (user != null) UserManager.AddToRole(user.Id, role.Name);
                }
            }
            return Ok(model);
        }


    }
}
