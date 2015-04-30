using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.DAL.Interface
{
    public interface SuperAdminHC
    {
        /*
        //Wat moet ik hiermee doen?
        void bepaalLayOut();
        void startPlatform();
        void bepaalUrl();
        */
        Admin createAdmin(Admin admin);
        void deleteAdmin(int id);
        void wijzigAdmin(Admin admin);
         
    }
}
