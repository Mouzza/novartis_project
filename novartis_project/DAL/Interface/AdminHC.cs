using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.DAL.Interface
{
    public interface AdminHC
    {
        
        VasteVraag createVastevraag(VasteVraag vastevraag);
        void deleteVastevraag(int id);
        void wijzigVastevraag(VasteVraag vastevraag);

        CentraleVraag createCentraleVraag(CentraleVraag centralevraag);
        void deleteCentralevraag(int id);
        void wijzigCentralevraag(CentraleVraag centralevraag);

        void setBeginDatumAgendaModule(DateTime startmoment, int id);
        void setEindDatumAgendaModule(DateTime eindmoment, int id);
        void wijzigBeginDatumAgendaModule(DateTime startmoment, int id);
        void wijzigEindDatumAgendaModule(DateTime eindmoment, int id);

        
        void deleteAgendaAntwoord(int id);
        void wijzigAgendaAntwoord(AgendaAntwoord agendaAntwoord);

        void deleteDossierAntwoord(int id);
        void wijzigDossierAntwoord(DossierAntwoord dossierAntwoord);

        void stelInAantalStemmen(int aantalstemmen, int id);

        void stelInVolledigheidsPercentage(int volledigheidsPercentage, int id);

        Expert setExpert(Expert expert);
        void deleteExpert(int id);
        void wijzigExpert(Expert expert);

        Moderator setModerator(Moderator moderator);
        void deleteModerator(int id);
        void wijzigModerator(Moderator moderator);

        DossierModule createDossierModule(DossierModule dossierModule);
        
    }
}
