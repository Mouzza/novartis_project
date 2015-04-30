using JPP.UI.Web.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using JPP.UI.Web.MVC;


namespace JPP.UI.Web.MVC.Controllers
{
 
    public class GebruikerController : Controller
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



        private ApplicationDbContext apc = new ApplicationDbContext();

        // GET: Gebruiker
        public ActionResult Profiel(string UserName)
        {

            User user = apc.Users.FirstOrDefault(u => u.UserName == UserName);

            var model = new UserRoleViewModel();


            var roles = user.Roles;
            var rolesCollection = new Collection<IdentityRole>();

            foreach (var role in roles)
            {
                var role1 = RoleManager.FindById(role.RoleId);
                rolesCollection.Add(role1);
            }

            model = new UserRoleViewModel { user = user, roles = rolesCollection };


            return View(model);
        }
        // /Gebruiker/WijzigGebruiker
        public ActionResult WijzigGebruiker(string id)
        {

            User user = apc.Users.FirstOrDefault(u => u.Id == id);
            return View(user);


        }

        // /Gebruiker/WijzigGebruiker
        [HttpPost]
        public async Task<ActionResult> WijzigGebruiker(string id, User user)
        {

            var store = new UserStore<User>(apc);
            var userManager = new UserManager<User>(store);

            try
            {
                // TODO: Add update logic here

                apc.Entry(user).State = System.Data.Entity.EntityState.Modified;

                await userManager.UpdateAsync(user);
                apc.SaveChanges();
                userManager.Update(user);
                apc.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {


                return RedirectToAction("Error","Admin");
            }

        }

        // /Gebruiker/VerwijderGebruiker
           [Authorize(Roles = "Admin")]
        public ActionResult VerwijderGebruiker(string id)
        {

            User user = apc.Users.Find(id);

            var model = new UserRoleViewModel();


            var roles = user.Roles;
            var rolesCollection = new Collection<IdentityRole>();

            foreach (var role in roles)
            {
                var role1 = RoleManager.FindById(role.RoleId);
                rolesCollection.Add(role1);
            }

            model = new UserRoleViewModel { user = user, roles = rolesCollection };


            return View(model);
        }


        // /Gebruiker/VerwijderGebruiker
           [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult VerwijderGebruiker(string id, FormCollection collection)
        {
            User user = apc.Users.FirstOrDefault(u => u.Id == id);

            try
            {
                // TODO: Add delete logic here
                if (user != null)
                {

                    apc.Users.Remove(user);
                    apc.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // /Gebruiker/BlokkeerGebruiker
           [Authorize(Roles = "Admin")]
        public ActionResult BlokkeerGebruiker(string id)
        {

            User user = apc.Users.Find(id);

            var model = new UserRoleViewModel();


            var roles = user.Roles;
            var rolesCollection = new Collection<IdentityRole>();

            foreach (var role in roles)
            {
                var role1 = RoleManager.FindById(role.RoleId);
                rolesCollection.Add(role1);
            }

            model = new UserRoleViewModel { user = user, roles = rolesCollection };


            return View(model);

        }
        [Authorize (Roles="Admin")]
        [HttpPost]
        // /Gebruiker/BlokkeerGebruiker
        public async Task<ActionResult> BlokkeerGebruiker(string id, FormCollection collection)
        {

          


            User user = apc.Users.FirstOrDefault(u => u.Id == id);
            var store = new UserStore<User>(apc);
            var userManager = new UserManager<User>(store);

            try
            {
                // TODO: Add update logic here
                if (user.LockoutEndDateUtc == null)
                {
                    user.LockoutEndDateUtc = DateTime.Now.AddDays(30);

                }
                else
                {
                    user.LockoutEndDateUtc = null;
                }


                await userManager.UpdateAsync(user);
                apc.SaveChanges();
                userManager.Update(user);
                apc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Admin");
            }


        }

        //Gebuiker/Gebruikers
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<User> users = apc.Users.ToList();
            var model = new Collection<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = user.Roles;
                var rolesCollection = new Collection<IdentityRole>();

                foreach (var role in roles)
                {
                    var role1 = RoleManager.FindById(role.RoleId);
                    rolesCollection.Add(role1);
                }

                model.Add(new UserRoleViewModel { user = user, roles = rolesCollection });
            }

            return View(model.ToPagedList(pageNumber, pageSize));
        }

          //Gebuiker/recenteGebruikers
           
           public ActionResult recenteGebruikers()
           {
               

               IEnumerable<User> users = apc.Users.ToList().OrderByDescending(u => u.Created);

               var model = new Collection<UserRoleViewModel>();

               for (int i = 0; i < 5;i++)
               {
                   var roles = users.ElementAt(i).Roles;
                   var rolesCollection = new Collection<IdentityRole>();

                   foreach (var role in roles)
                   {
                       var role1 = RoleManager.FindById(role.RoleId);
                       rolesCollection.Add(role1);
                   }

                   model.Add(new UserRoleViewModel { user = users.ElementAt(i), roles = rolesCollection });
               }

               return View(model);
           }


    }
}