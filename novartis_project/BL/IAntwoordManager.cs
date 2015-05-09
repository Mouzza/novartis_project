using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;

namespace JPP.BL
{
    public interface IAntwoordManager
    {
        List<DossierAntwoord> topDossierAntwoorden(int top);
        List<AgendaAntwoord> topAgendaAntwoorden(int top);
        Antwoord readAntwoord(int id);
        List<DossierAntwoord> readAllDossierAntwoorden();
        List<AgendaAntwoord> readAllAgendaAntwoorden();
        List<Antwoord> readAllAntwoorden();
        //Antwoord createAntwoord(Antwoord antwoord);
        //void updateAntwoord(Antwoord antwoord);

        List<DossierAntwoord> getAllDossierAntwoordenPerModule(int moduleID);
        List<AgendaAntwoord> getAllAgendaAntwoordenPerModule(int agendaID);
        void removeAntwoord(int id); 
    }
}
