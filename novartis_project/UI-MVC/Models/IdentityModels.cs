using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JPP.DAL.EF;
using System;
using JPP.BL.Domain.Antwoorden;

namespace JPP.UI.Web.MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public virtual DateTime Created { get; set; }
        public virtual Nullable<DateTime> LastLogin { get; set; }
        public virtual Boolean profilePublic { get; set; }
        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual int Zipcode { get; set; }   
   

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        
        }

        public string getEmail()
        {
            return this.Email;
        }
    }
    public class Role : IdentityRole
    {

    }
    [DbConfigurationType(typeof(EFDbConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("dbteamnovartis", throwIfV1Schema: false)
        {
        }
        //Voor roles
        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
        //

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Tabel namen veranderen en bepaalde keys ook , eerst add-migration "naam" en dan update-database in package manager console
            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Role").Property(p => p.Id).HasColumnName("RoleId");
        }
    }
}