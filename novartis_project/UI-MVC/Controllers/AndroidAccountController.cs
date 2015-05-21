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
        public async Task<IHttpActionResult> Register(ANDROIDGebruiker model)
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
                    AccessFailedCount=0
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
        private ApplicationDbContext apc = new ApplicationDbContext();
        #region login
        [HttpGet]
        [ActionName("login1")]
        public IHttpActionResult login(string userN, string pas)
        {
            List<User> users = apc.Users.ToList();
            ANDROIDGebruiker returnUser = new ANDROIDGebruiker();
            foreach(var user in users)
            {
                if (user.UserName == userN && user.PasswordHash == pas)
                {
                    returnUser.Birthday = user.Birthday;
                    returnUser.Email = user.Id;
                    returnUser.FirstName = user.FirstName ;
                    returnUser.id = user.Id;
                    returnUser.LastName = user.LastName;
                    returnUser.Name = user.UserName;
                    returnUser.Password = user.PasswordHash;
                    returnUser.Zipcode = user.Zipcode;
                    break;
                }
            }
            return Ok(returnUser);
        }
        #endregion

      
        [HttpPost]
        [ActionName("login")]
        public async Task<IHttpActionResult> Login(ANDROIDLoginView model)
        {
            User us = null;
            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.Name);
            if (user == null)
            {
                return Ok(us);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Name, model.Password, false, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    user.LastLogin = DateTime.Now;
                    var store = new UserStore<User>(new ApplicationDbContext());
                    UserManager.Update(user);
                    var ctx = store.Context;
                    ctx.SaveChanges();
                    return Ok(user);
                case SignInStatus.Failure:
                    return Ok(us);
                default:
                    return Ok(us);
            }
        }
    }
}
