using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using System.Web.Services.Description;
using System.Net.Mime;
using JPP.UI.Web.MVC.Models;

namespace JPP.UI.Web.MVC

{

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>    {

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }



        //maak user admin@admin.be met wachtwoord Admin01! met Admin role
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {

            var UserManager = new UserManager<User>(new UserStore<User>(db));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            string name = "";
            string email = "";
            string password = "";
            string roleName = "";
            string voornaam = "Dummyvoornaam";
            string achternaam = "Dummyachternaam";
            int postcode = 2000;
            DateTime geboortedatum = DateTime.Now;


            //Gebruiker
            //maak roll Gebruiker
            //Create Role Gebruiker if it does not exist

            roleName = "Gebruiker";
            var role = RoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = RoleManager.Create(role);
            }



   

            //maak dummy gebruikers aan
            for (int i = 0; i < 6; i++)
            {
                name = "Gebruiker" + i;
                email = "gebruiker" + i + "@test.be";
                password = "Gebruiker0" + i;
                roleName = "Gebruiker";

                var gebruiker = UserManager.FindByName(name);
                if (gebruiker==null)
                {
                     gebruiker = new User { UserName = name, 
                                            Email = email, 
                                            Created = DateTime.Now, 
                                            EmailConfirmed = true, 
                                            profilePublic=true,  
                                            Birthday = geboortedatum, 
                                            FirstName = voornaam, 
                                            LastName = achternaam, 
                                            Zipcode = postcode};

                     var result = UserManager.Create(gebruiker, password);
                     result = UserManager.SetLockoutEnabled(gebruiker.Id, true);
                }

                var rolesVoorGebruiker = UserManager.GetRoles(gebruiker.Id);
                if (!rolesVoorGebruiker.Contains(roleName))
                {
                    var result = UserManager.AddToRole(gebruiker.Id, roleName);
                }
               
             

            }


            //Admin----------------------------------------------
            name = "Admin";
            email = "admin@admin.be";
            password = "Admin01";

            roleName = "Admin";

            //Create Role Admin if it does not exist

            role = RoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = RoleManager.Create(role);
            }
            //Create User=Admin with password

            var user = UserManager.FindByName(name);

            if (user == null)
            {

                user = new User
                {
                    UserName = name,
                    Email = email,
                    Created = DateTime.Now,
                    EmailConfirmed = true,
                    profilePublic = true,
                    Birthday = geboortedatum,
                    FirstName = voornaam,
                    LastName = achternaam,
                    Zipcode = postcode
                };

                var result = UserManager.Create(user, password);
                result = UserManager.SetLockoutEnabled(user.Id, false);
            }

            //Add User Admin to Role Admin if not already added
            var rolesForUser = UserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = UserManager.AddToRole(user.Id, roleName);
            }

      
            //Moderator ------------------------------------------
             name = "Moderator";
             email = "moderator@mod.be";
             password = "Moderator01";

             roleName = "Moderator";


             //Create Role Moderator if it does not exist

             role = RoleManager.FindByName(roleName);
             if (role == null)
             {
                 role = new IdentityRole(roleName);
                 var roleresult = RoleManager.Create(role);
             }

            //Maak moderator gebruiker aan
             user = UserManager.FindByName(name);

            if (user == null)
            {

                user = new User
                {
                    UserName = name,
                    Email = email,
                    Created = DateTime.Now,
                    EmailConfirmed = true,
                    profilePublic = true,
                    Birthday = geboortedatum,
                    FirstName = voornaam,
                    LastName = achternaam,
                    Zipcode = postcode
                };
                var result = UserManager.Create(user, password);
                result = UserManager.SetLockoutEnabled(user.Id, false);
            }

            //Add User Mod to Role Moderator if not already added
            rolesForUser = UserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = UserManager.AddToRole(user.Id, roleName);
            }

            //Expert----------------------------------------------
            name = "Expert";
            email = "expert@expert.be";
            password = "Expert01";

            roleName = "Expert";

            //Create Role Expert if it does not exist

            role = RoleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = RoleManager.Create(role);
            }
            //Create User=Expert with password

            user = UserManager.FindByName(name);

            if (user == null)
            {

                user = new User
                {
                    UserName = name,
                    Email = email,
                    Created = DateTime.Now,
                    EmailConfirmed = true,
                    profilePublic = true,
                    Birthday = geboortedatum,
                    FirstName = voornaam,
                    LastName = achternaam,
                    Zipcode = postcode
                };

                var result = UserManager.Create(user, password);
                result = UserManager.SetLockoutEnabled(user.Id, false);
            }

            //Add User Admin to Role Admin if not already added
            rolesForUser = UserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = UserManager.AddToRole(user.Id, roleName);
            }


           
        }
    }
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            /*
            // Credentials:
            var credentialUserName = "email";
            var sentFrom = "email";
            var pwd = "appcode";

            // Configure the client:
            System.Net.Mail.SmtpClient client =
                new System.Net.Mail.SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Creatte the credentials:
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail =
                new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send:
            return client.SendMailAsync(mail);*/
            return Task.FromResult(0);

        }


    }
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store)
            : base(store)
        {
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>());
            return new ApplicationRoleManager(roleStore);
        }
    }
}
