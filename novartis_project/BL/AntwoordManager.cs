﻿using System;
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
<<<<<<< HEAD

        public List<AgendaAntwoord> sortAgendaAntwoordOudNieuw()
        {
            return inlog.getAllAgendaAntwoorden().OrderBy(o => o.datum).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordNieuwOud()
        {
            return inlog.getAllAgendaAntwoorden().OrderByDescending(o => o.datum).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordMeesteLikes()
        {
            return inlog.getAllAgendaAntwoorden().OrderByDescending(o => o.aantalStemmen).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordMinsteLikes()
        {
            return inlog.getAllAgendaAntwoorden().OrderBy(o => o.aantalStemmen).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordAZ()
        {
            return inlog.getAllAgendaAntwoorden().OrderBy(o => o.titel).ToList();
        }

        public List<AgendaAntwoord> sortAgendaAntwoordZA()
        {
            return inlog.getAllAgendaAntwoorden().OrderByDescending(o => o.titel).ToList();
        }
=======
        #region sortDossierAntwoord
        public List<DossierAntwoord> sortDossierAntwoordNieuwOud()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderBy(o => o.datum).ToList();
            return dossierRes;
        }
        public List<DossierAntwoord> sortDossierAntwoordOudNieuw()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderByDescending(o => o.datum).ToList();
            return dossierRes;
        }
        public List<DossierAntwoord> sortDossierAntwoordMeesteLikes()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderByDescending(o => o.aantalStemmen).ToList();
            return dossierRes;
        }
        public List<DossierAntwoord> sortDossierAntwoordMinsteLikes()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderBy(o => o.aantalStemmen).ToList();
            return dossierRes;
        }
        public List<DossierAntwoord> sortDossierAntwoordTitelAZ()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderBy(o => o.titel).ToList();
            return dossierRes;
        }
        public List<DossierAntwoord> sortDossierAntwoordTitelZA()
        {
            List<DossierAntwoord> dossierList = inlog.getAllDossierAntwoorden();
            List<DossierAntwoord> dossierRes = dossierList.OrderByDescending(o => o.titel).ToList();
            return dossierRes;
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

>>>>>>> origin/master

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