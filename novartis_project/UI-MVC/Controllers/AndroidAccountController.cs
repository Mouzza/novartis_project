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
using JPP.BL.Domain.Gebruikers;
using JPP.BL;




namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidAccountController : ApiController
    {
        ModuleManager modman = new ModuleManager();
        #region REGISTER
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
        [HttpPost]
        [ActionName("Register")]
        public async Task<IHttpActionResult> Register(AndroidGebruiker model)
        {
                var user = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    Created = DateTime.Now,
                    profilePublic = true,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    Zipcode = model.Zipcode,
                    LockoutEnabled=false,
                    EmailConfirmed=true,
                    AccessFailedCount=0,
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = RoleManager.FindByName("Gebruiker");

                    if (user != null) UserManager.AddToRole(user.Id, role.Name);
                }
          
            return Ok(model);
        }
        #endregion

        #region login
        [HttpGet]
        [ActionName("login")]
        public IHttpActionResult login(string user,string password)
        {
            List<Gebruiker> gebruikers = modman.readGebruikers();
            AndroidGebruiker returnGebruiker = new AndroidGebruiker();
            foreach(var geb in gebruikers)
            {
                if (geb.gebruikersnaam == user && geb.wachtwoord == password)
                {
                    returnGebruiker.active = geb.active;
                    returnGebruiker.Birthday = geb.geboorteDatum;
                    returnGebruiker.ConfirmPassword = geb.wachtwoord;
                    returnGebruiker.Email = geb.email;
                    returnGebruiker.FirstName = geb.voornaam;
                    returnGebruiker.id = geb.id;
                    returnGebruiker.LastName = geb.achternaam;
                    returnGebruiker.Name = geb.gebruikersnaam;
                    returnGebruiker.Password = geb.wachtwoord;
                    returnGebruiker.Zipcode = geb.postcode;
                }
            }
            return Ok(returnGebruiker);
        }
        #endregion

    }
}
