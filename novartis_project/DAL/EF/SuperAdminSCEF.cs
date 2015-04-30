using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.DAL.EF
{
    class SuperAdminSCEF : SuperAdminHC
    {
        EFDbContext dbcontext;
        public SuperAdminSCEF()
        {
            dbcontext = new EFDbContext();
        }
        public Admin createAdmin(Admin admin)
        {
            dbcontext.admin.Add(admin);
            dbcontext.SaveChanges();
            return admin;
        }

        public void deleteAdmin(int ID)
        {
            Admin admin = dbcontext.admin.Find(ID);
            dbcontext.admin.Remove(admin);
            dbcontext.SaveChanges();
        }

        public void wijzigAdmin(Admin admin)
        {
            dbcontext.Entry(admin).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
