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

        public List<AgendaAntwoord> sortAgendaAntwoordOudNieuw(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderBy(o => o.datum).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordNieuwOud(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderByDescending(o => o.datum).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordMeesteLikes(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderByDescending(o => o.aantalStemmen).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordMinsteLikes(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderBy(o => o.aantalStemmen).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordAZ(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderBy(o => o.titel).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordZA(IEnumerable<AgendaAntwoord> agendaAntwoorden)
        {
            return agendaAntwoorden.OrderByDescending(o => o.titel).ToList();
        }

        #region sortDossierAntwoord
        public List<DossierAntwoord> sortDossierAntwoordNieuwOud(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {


            return dossierAntwoorden.OrderBy(o => o.datum).ToList();
        }
        public List<DossierAntwoord> sortDossierAntwoordOudNieuw(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {


            return dossierAntwoorden.OrderByDescending(o => o.datum).ToList();
        }
        public List<DossierAntwoord> sortDossierAntwoordMeesteLikes(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {
      
            return dossierAntwoorden.OrderByDescending(o => o.aantalStemmen).ToList();
        }
        public List<DossierAntwoord> sortDossierAntwoordMinsteLikes(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {

            return dossierAntwoorden.OrderBy(o => o.aantalStemmen).ToList();
        }
        public List<DossierAntwoord> sortDossierAntwoordTitelAZ(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {

            return dossierAntwoorden.OrderBy(o => o.titel).ToList();
        }
        public List<DossierAntwoord> sortDossierAntwoordTitelZA(IEnumerable<DossierAntwoord> dossierAntwoorden)
        {

            return dossierAntwoorden.OrderByDescending(o => o.titel).ToList(); ;
        }
        #endregion

        #region GET SORT Gesloten modules
        public List<Antwoord> getAllGeslotenModules()
        {
            List<Antwoord> antwoordList = inlog.getAllAntwoorden();
            return antwoordList;
        }
        public List<Antwoord> sortGeslotenModulesNieuwOud()
        {
            List<Antwoord> antwoordList = inlog.getAllAntwoorden();
            List<Antwoord> antwoordRes = antwoordList.OrderBy(o => o.datum).ToList();
            return antwoordList;
        }
        public List<Antwoord> sortGeslotenModulesOudNieuw()
        {
            List<Antwoord> antwoordList = inlog.getAllAntwoorden();
            List<Antwoord> antwoordRes = antwoordList.OrderByDescending(o => o.datum).ToList();
            return antwoordList;
        }
        public List<Antwoord> sortGeslotenModulesMeesteLikes()
        {
            List<Antwoord> antwoordList = inlog.getAllAntwoorden();
            List<Antwoord> antwoordRes = antwoordList.OrderByDescending(o => o.aantalStemmen).ToList();
            return antwoordRes;
        }
        public List<Antwoord> sortGeslotenModulesMinsteLikes()
        {
            List<Antwoord> antwoordList = inlog.getAllAntwoorden();
            List<Antwoord> antwoordRes = antwoordList.OrderBy(o => o.aantalStemmen).ToList();
            return antwoordRes;
        }

        #endregion


        public Antwoord readAntwoord(int id)
        {
           return inlog.getAntwoord(id);
        }

        public DossierAntwoord readDossierAntwoord(int id)
        {
            return inlog.getDossierAntwoord(id);
        }

        public AgendaAntwoord readAgendaAntwoord(int id)
        {
            return inlog.getAgendaAntwoord(id);
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



        public Antwoord createDossierAntwoord(DossierAntwoord dossierAntwoord)
        {
            //ModuleManager modMan = new ModuleManager();

            //dossierAntwoord.module = modMan.readActieveDossierModule();
            //DossierModule module = (DossierModule)inlog.getModule(dossierAntwoord.module.ID);
            //module.dossierAntwoorden.Add(dossierAntwoord);

            return inlog.maakDossierAntwoord(dossierAntwoord);

        }
        public Antwoord createAgendaAntwoord(AgendaAntwoord agendaAntwoord)
        {
            

            return inlog.maakAgendaAntwoord(agendaAntwoord);
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
        public void stemOpComment(int id)
        {
            beheerder.stemOpComment(id);
        }
        public void stemOpAntwoord(int id)
        {
            beheerder.stemOpAntwoord(id);
        }

         
    }
}