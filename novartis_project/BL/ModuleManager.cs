﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.EF;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;

namespace JPP.BL
{
    public class ModuleManager:IModuleManager
    {
        //IngelogdeGebruikerSCEF inlog;
        NietIngelogdeGebruikerSCEF nietInlog;
       /* public List<Module> topModules(int top)
        {
            throw new NotImplementedException();
            //List<Module> moduleList = inlog.getModules;
            //List<Module> moduleTussenRes = moduleList.OrderBy(o => o.).ToList();
            //List<Module> commentReturn = new List<Comment>();
            //for (int i = 0; i < top; i++)
            //{
            //    commentReturn.Add(commentTussenRes[i]);
            //}
            //return commentReturn;

        }*/

        AdminSCEF admin;
        public ModuleManager()
        {
            nietInlog = new NietIngelogdeGebruikerSCEF();
            admin = new AdminSCEF();
        }


        

        public Module readModule(int id)
        {
            return nietInlog.getModule(id);
        }

        public DossierModule readActieveDossierModule()
        {
            //CHECK kan het zelfde zijn als read module er is maar 1 actieveVraag per keer dus nrml geizen geen ID
            List<DossierModule> modules = nietInlog.getDossierModules();
            Module moduleTussen=new DossierModule();
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules[i].beginDatum < DateTime.Today && modules[i].eindDatum > DateTime.Today)
                {
                    moduleTussen = modules[i];
                }
            }
            return (DossierModule)moduleTussen;
        }

        public AgendaModule readActieveAgendaModule()
        {
            ////CONTROLEEEEE agenda en dossier zitten samen in module
            List<AgendaModule> modules = nietInlog.getAgendaModules();
            Module moduleTussen = new AgendaModule();
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules[i].beginDatum < DateTime.Today && modules[i].eindDatum > DateTime.Today)
                {
                    moduleTussen = modules[i];
                }
            }
            return (AgendaModule)moduleTussen;
        }

        public List<DossierModule> readAllDossierModules()
        {
            List<DossierModule> modules = nietInlog.getDossierModules();
            return modules;
        }

        public List<AgendaModule> readAllAgendaModules()
        {
            List<AgendaModule> agendaModule = nietInlog.getAgendaModules();
            return agendaModule;
        }

        public List<Module> readGeplandeModules()
        {
            List<Module> modules = nietInlog.getModules();
            List<Module> moduleTussen = new List<Module>();
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules[i].beginDatum > DateTime.Today)
                {
                    moduleTussen.Add(modules[i]);
                }
            }
            return moduleTussen;
        }
        
        public DossierModule createDossierModule(DossierModule dossierModule)
        {
            CentraleVraag centraleVraag = new CentraleVraag()
            {
                inhoud = dossierModule.centraleVraag.inhoud,
                aantalWinAntwoorden = dossierModule.centraleVraag.aantalWinAntwoorden,
                extraInfo = dossierModule.centraleVraag.extraInfo,
                datum = DateTime.Now


            };

            Thema thema = new Thema()
            {
                beschrijving = dossierModule.thema.beschrijving,
                naam = dossierModule.thema.naam,

            };

            //List<VasteVraag> vasteVragen = new List<VasteVraag>();
            //foreach (var vasteVraag in dossierModule.vasteVragen)
            //{
            //    VasteVraag vasteVraagX = new VasteVraag()
            //    {
            //        boolVerplicht = vasteVraag.boolVerplicht,
            //        inhoud = vasteVraag.inhoud,
            //        extraInfo = vasteVraag.extraInfo,



            //    };
            //    vasteVragen.Add(vasteVraagX);
            //}




         
                Beloning beloning = new Beloning()
                {
                    naam = dossierModule.beloning.naam,
                    beschrijving = dossierModule.beloning.beschrijving
                    

                };
         

            DossierModule moduleX = new DossierModule()
            {

               
                status = dossierModule.status,
                adminNaam = dossierModule.adminNaam,
                beginDatum = dossierModule.beginDatum,
                eindDatum = dossierModule.eindDatum,
                //vasteVragen = new List<VasteVraag>(),
                verplichteVolledigheidsPercentage = dossierModule.verplichteVolledigheidsPercentage,
                naam = dossierModule.naam


            };

            moduleX.beloning = beloning;
            //dossierModule.vasteVragen = vasteVragen;
            moduleX.centraleVraag = centraleVraag;
            moduleX.thema = thema;

            return admin.createDossierModule(moduleX);
        }

        public void updateModule(Module module)
        {
            admin.wijzigModule(module);
        }

        public void removeModule(int id)
        {
            admin.deleteModule(id);
        }
    }
}
