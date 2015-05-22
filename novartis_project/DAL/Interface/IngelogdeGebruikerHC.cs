using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Antwoorden;


namespace JPP.DAL.Interface
{
    public interface IngelogdeGebruikerHC
    {





        DossierAntwoord maakDossierAntwoord(DossierAntwoord dossierAntwoord);


        AgendaAntwoord maakAgendaAntwoord(AgendaAntwoord agendaAntwoord);
    
         
    }
}
