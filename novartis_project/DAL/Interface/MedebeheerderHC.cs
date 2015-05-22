using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Vragen;

namespace JPP.DAL.Interface
{
    public interface MedebeheerderHC
    {
        
        //void deleteVoorstel(Voorstel voorstel);
        //void wijzigVoorstel(Voorstel voorstel);

        void deleteAntwoord(int id);
        //void wijzigAntwoord(Antwoord antwoord);

        //void deleteDossierAntwoord(int id);
        void wijzigDossierAntwoord(DossierAntwoord dossierAntwoord);
        //delete of inactief zetten
        //void deleteAgendaAntwoord(int id);
        void wijzigAgendaAntwoord(AgendaAntwoord agendeaAntwoord);
    
         
    }
}
