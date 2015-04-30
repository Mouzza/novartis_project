using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.DAL.Interface
{
    public interface IngelogdeGebruikerHC
    {



        //Kan een voorstel maken???
        Beheerder createBeheerder(Beheerder beheerder);
        //Voorstel maakVoorstel(Voorstel voorstel);


        
        void deleteGebruiker(int id);
       
        void wijzigGebruiker(Gebruiker gebruiker);


//        Antwoord maakAntwoord(Antwoord antwoord);

        DossierAntwoord maakDossierAntwoord(DossierAntwoord dossierAntwoord);


        AgendaAntwoord maakAgendaAntwoord(AgendaAntwoord agendaAntwoord);
    
         
    }
}
