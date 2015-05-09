using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.DAL.EF;
using JPP.BL.Domain.Modules;

namespace JPP.BL
{
    public class AntwoordManager:IAntwoordManager
    {
        IngelogdeGebruikerSCEF inlog;
        BeheerderSCEF beheerder;

        public AntwoordManager()
        {
            inlog = new IngelogdeGebruikerSCEF();
            beheerder = new BeheerderSCEF();
        }
        public List<DossierAntwoord> topDossierAntwoorden(int top)
        {
            List<DossierAntwoord> dossierList=inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierTussenRes = dossierList.OrderBy(o => o.aantalStemmen).ToList();
            List<DossierAntwoord> dossierReturn=new List<DossierAntwoord>(); 
            for (int i = 0; i < top; i++)
            {
                dossierReturn.Add(dossierTussenRes[i]);
            }
            return dossierReturn;
        }
        public List<Antwoord> readAllAntwoorden()
        {
            List<Antwoord> antwoorden = inlog.getAllAntwoorden();
            return antwoorden;
       
        }
        public List<DossierAntwoord> getAllDossierAntwoordenPerModule(int moduleID)
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierReturn=new List<DossierAntwoord>(); 
            foreach (var dossier in dossierList)
            {
                if (dossier.module.ID == moduleID)
                {
                    dossierReturn.Add(dossier);
                }
            }

            return dossierReturn;
        }

        public List<AgendaAntwoord> getAllAgendaAntwoordenPerModule(int agendaID)
        {
            List<AgendaAntwoord> agendaList = inlog.getAllAgendaAntwoorden();
            List<AgendaAntwoord> agendaReturn = new List<AgendaAntwoord>();
            foreach (var agenda in agendaList)
            {
                if (agenda.module.ID == agendaID)
                {
                    agendaReturn.Add(agenda);
                }
            }

            return agendaReturn;
        }

        public List<AgendaAntwoord> topAgendaAntwoorden(int top)
        {
            List<AgendaAntwoord> agendaList=inlog.getAllAgendaAntwoorden();
            List<AgendaAntwoord> agendaTussenRes = agendaList.OrderBy(o => o.aantalStemmen).ToList();
            List<AgendaAntwoord> agendaReturn=new List<AgendaAntwoord>(); 
            for (int i = 0; i < top; i++)
            {
                agendaReturn.Add(agendaTussenRes[i]);
            }
            return agendaReturn;
        }

        public Antwoord readAntwoord(int id)
        {
           return inlog.getAntwoord(id);
        }

        public List<DossierAntwoord> readAllDossierAntwoorden()
        {
            List<DossierAntwoord> dossierReturn = inlog.getAllDossierAntwoorden();
            return dossierReturn;
        }

        public List<AgendaAntwoord> readAllAgendaAntwoorden()
        {
            List<AgendaAntwoord> agendaReturn = inlog.getAllAgendaAntwoorden();
            return agendaReturn;
        }

        

        public Antwoord createDossierAntwoord(Antwoord antwoord)
        {
           return inlog.maakDossierAntwoord((DossierAntwoord)antwoord);
        }

        public Antwoord createAgendaAntwoord(Antwoord antwoord)
        {
            return inlog.maakAgendaAntwoord((AgendaAntwoord)antwoord);
        }

        
        public void updateAgendaAntwoord(Antwoord antwoord)
        {
            beheerder.wijzigAgendaAntwoord((AgendaAntwoord)antwoord);
        }
        public void updateDossierAntwoord(Antwoord antwoord)
        {
            beheerder.wijzigDossierAntwoord((DossierAntwoord)antwoord);
        }


        public void removeAntwoord(int id)
        {
            beheerder.deleteAntwoord(id);
        }
    }
}
