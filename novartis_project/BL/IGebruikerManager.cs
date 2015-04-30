using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Gebruikers;

namespace JPP.BL
{
    interface IGebruikerManager
    {
        Gebruiker maakGebruiker(Gebruiker gebruiker);
        void deleteGebruiker(Gebruiker gebruiker);
        void wijzigGebruiker(Gebruiker gebruiker);
        Gebruiker getGebruiker(int ID);

        void makeModerator(Gebruiker gebruiker);
        void makeBeheerder(Gebruiker gebruiker);
        void makeExpert(Gebruiker gebruiker);
        void makeAdmin(Gebruiker gebruiker);
        void makeSuperAdmin(Gebruiker gebruiker);

        void deleteModerator(Gebruiker gebruiker);
        void deleteBeheerder(Gebruiker gebruiker);
        void deleteExpert(Gebruiker gebruiker);
        void deleteAdmin(Gebruiker gebruiker);
        void deleteSuperAdmin(Gebruiker gebruiker);

        Gebruiker getModerator(int gebruikerId);
        Gebruiker getBeheerder(int gebruikerId);
        Gebruiker getMedebeheerder(int gebruikerId);
        Gebruiker getExpert(int gebruikerId);
        Gebruiker getAdmin(int gebruikerId);
        Gebruiker getSuperAdmin(int gebruikerId);
    }
}
