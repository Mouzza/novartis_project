using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using JPP.UI.Web.MVC.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JPP.UI.Web.MVC.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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

        private ApplicationDbContext apc = new ApplicationDbContext();
        // /Manage/Index
        public ActionResult Index()
        {

            return View();
        }



        public ActionResult ProfielPartial()
        {

            User user = apc.Users.Find(User.Identity.GetUserId());

            var model = new UserRoleViewModel();


            var roles = user.Roles;
            var rolesCollection = new Collection<IdentityRole>();

            foreach (var role in roles)
            {
                var role1 = RoleManager.FindById(role.RoleId);
                rolesCollection.Add(role1);
            }

            model = new UserRoleViewModel { user = user, roles = rolesCollection };


            return PartialView(model);
        }


        // /Manage/Profiel

        public ActionResult Profiel()
        {

            User user = apc.Users.Find(User.Identity.GetUserId());

            var model = new UserRoleViewModel();

      
                        var roles = user.Roles;
                        var rolesCollection = new Collection<IdentityRole>();

                        foreach (var role in roles)
                        {
                            var role1 =  RoleManager.FindById(role.RoleId);
                            rolesCollection.Add(role1);
                        }

                        model = new UserRoleViewModel { user = user, roles = rolesCollection };
                    

               return View(model);
            }


        // GET: /Manage/AccountInstellingen
        public async Task<ActionResult> AccountInstellingen(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Uw wachtwoord is gewijzigd."
                : message == ManageMessageId.SetPasswordSuccess ? "Uw wachtwoord is ingesteld."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Uw two-factor authenticatie provider is ingesteld."
                : message == ManageMessageId.Error ? "Een error is aanwezig."
                : message == ManageMessageId.AddPhoneSuccess ? "Uw GSM-nummer is toegevoegd."
                : message == ManageMessageId.RemovePhoneSuccess ? "Uw GSM-nummer is verwijderd."
                : "";
                    

            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(User.Identity.GetUserId()),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(User.Identity.GetUserId()),
                Logins = await UserManager.GetLoginsAsync(User.Identity.GetUserId()),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(User.Identity.GetUserId())
            };
            return View(model);
        }


        // /Manage/AccountInstellingen2
       
        public ActionResult InstellingenPartial()
        {

            User user = apc.Users.Find(User.Identity.GetUserId());
            return PartialView(user);


        }

        
        // /Manage/AccountInstellingen2

      [HttpPost]
        public ActionResult InstellingenPartial(string id, User user)
        {

            var store = new UserStore<User>(apc);
            var userManager = new UserManager<User>(store);

            try
            {
                // TODO: Add update logic here

                apc.Entry(user).State = System.Data.Entity.EntityState.Modified;

             
                userManager.Update(user);
                apc.SaveChanges();

                return RedirectToAction("AccountInstellingen");
            }
            catch
            {

                return PartialView("ErrorPartial");
              
            }

        }
       
        //
        // GET: /Manage/RemoveLogin
        public ActionResult RemoveLogin()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return View(linkedAccounts);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Uw beveiligingscode is: " + code
                };
                // dit is nodig om de code te verzende via een sms provider (bv Twilio)
                //await UserManager.SmsService.SendAsync(message);
                // View("VerifyPhoneNumber").ViewBag.VCode = code;
            }



            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number, Code = code });

        }

        [HttpPost]
        public async Task<ActionResult> zetProfielPubliek()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var store = new UserStore<User>(apc);
            var userManager = new UserManager<User>(store);
            user.profilePublic = true;
            
            try
            {
                // TODO: Add update logic here

                apc.Entry(user).State = System.Data.Entity.EntityState.Modified;

                await userManager.UpdateAsync(user);
                apc.SaveChanges();
                userManager.Update(user);
                apc.SaveChanges();

                return RedirectToAction("Index","Manage");
            }
            catch
            {


                return RedirectToAction("Error", "Shared");
            }
        }

        [HttpPost]
        public async Task<ActionResult> zetProfielPrive()
        {

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var store = new UserStore<User>(apc);
            var userManager = new UserManager<User>(store);
            user.profilePublic = false;

            try
            {
                // TODO: Add update logic here

                apc.Entry(user).State = System.Data.Entity.EntityState.Modified;

                await userManager.UpdateAsync(user);
                apc.SaveChanges();
                userManager.Update(user);
                apc.SaveChanges();

                return RedirectToAction("Index", "Manage");
            }
            catch
            {


                return RedirectToAction("Error", "Shared");
            }
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Verifiëren van gsm is gefaald");
            return View(model);
        }

        //
        // GET: /Manage/RemovePhoneNumber
        public async Task<ActionResult> RemovePhoneNumber()
        {

            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInAsync(user, isPersistent: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
 
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "de externe login is verwijderd."
                : message == ManageMessageId.Error ? "Er is een error aanwezig."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}