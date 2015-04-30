using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Antwoorden;

namespace JPP.DAL.Interface
{
    public interface NietIngelogdeGebruikerHC
    {
        /*
        //Inloggen en gebruiker aanmaken
        Gebruiker maakGebruiker(Gebruiker gebruiker);
        Gebruiker Login(Gebruiker gebruiker);

        //Informatie van de website bekijken
        Module getVasteVraag(int ID);
        Organisatie getOrganisatie(int ID);

        Beloning getBeloning(int ID);

        Thema getThema(int ID);
        int getVolledigheidsPercentage();
        VasteVraag getVasteVraag(int ID);
        Voorstel getVoorstel(int ID);

        Gebruiker getModerator(int gebruikerId);
        Gebruiker getBeheerder(int gebruikerId);
        Gebruiker getMedebeheerder(int gebruikerId);
        Gebruiker getExpert(int gebruikerId);

        //Kan iedereen de admin en superadmin opvragen? 
        Gebruiker getAdmin(int gebruikerId);
        Gebruiker getSuperAdmin(int gebruikerId);

        Antwoord getAntwoord(int ID);
        DossierAntwoord getDossierAntwoord(int ID);
        AgendaAntwoord getAgendaAntwoord(int ID);
         * */
    }
}
