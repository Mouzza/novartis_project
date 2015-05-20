using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.EF;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Gebruikers;

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
         

            DossierModule dossierModuleX = new DossierModule()
            {

               
                status = dossierModule.status,
                adminNaam = dossierModule.adminNaam,
                beginDatum = dossierModule.beginDatum,
                eindDatum = dossierModule.eindDatum,
                //vasteVragen = new List<VasteVraag>(),
                verplichteVolledigheidsPercentage = dossierModule.verplichteVolledigheidsPercentage,
                naam = dossierModule.naam


            };

            dossierModuleX.beloning = beloning;
            //dossierModule.vasteVragen = vasteVragen;
            dossierModuleX.centraleVraag = centraleVraag;
            dossierModuleX.thema = thema;

            return admin.maakDossierModule(dossierModuleX);
        }

        public AgendaModule createAgendaModule(AgendaModule agendaModule)
        {
            CentraleVraag centraleVraag = new CentraleVraag()
            {
                inhoud = agendaModule.centraleVraag.inhoud,
                aantalWinAntwoorden = agendaModule.centraleVraag.aantalWinAntwoorden,
                extraInfo = agendaModule.centraleVraag.extraInfo,
                datum = DateTime.Now


            };

            Thema thema = new Thema()
            {
                beschrijving = agendaModule.thema.beschrijving,
                naam = agendaModule.thema.naam,

            };
  
            Beloning beloning = new Beloning()
            {
                naam = agendaModule.beloning.naam,
                beschrijving = agendaModule.beloning.beschrijving


            };


            AgendaModule agendaModuleX = new AgendaModule()
            {


                status = agendaModule.status,
                adminNaam = agendaModule.adminNaam,
                beginDatum = agendaModule.beginDatum,
                eindDatum = agendaModule.eindDatum,          
                naam = agendaModule.naam


            };

            agendaModuleX.beloning = beloning;
            agendaModuleX.centraleVraag = centraleVraag;
            agendaModuleX.thema = thema;

            return admin.maakAgendaModule(agendaModuleX);
        }

        public void updateDossierModule(DossierModule dossierModule)
        {
            admin.wijzigDossierModule(dossierModule);
        }
        public void updateAgendaModule(AgendaModule agendaModule)
        {
            admin.wijzigAgendaModule(agendaModule);
        }

        public void removeDossierModule(int id)
        {
            admin.deleteDossierModule(id);
        }

        public void removeAgendaModule(int id)
        {
            admin.deleteAgendaModule(id);
        }

        public List<DossierModule> readGeslotenDossiers()
        {
            List<DossierModule> dossierModules = nietInlog.getDossierModules();
            List<DossierModule> moduleTussen = new List<DossierModule>();
            for (int i = 0; i < dossierModules.Count; i++)
            {
                if (dossierModules[i].eindDatum <= DateTime.Today)
                {
                    moduleTussen.Add(dossierModules[i]);
                }
            }
            return moduleTussen;
        }

        public List<Module> readGeslotenModules()
        {
            List<Module> Modules = nietInlog.getModules();
            List<Module> moduleTussen = new List<Module>();
            for (int i = 0; i < Modules.Count; i++)
            {
                if (Modules[i].eindDatum <= DateTime.Today)
                {
                    moduleTussen.Add(Modules[i]);
                }
            }
            return moduleTussen;
        }

        public List<AgendaModule> readGeslotenAgendas()
        {
            List<AgendaModule> agendaModules = nietInlog.getAgendaModules();
            List<AgendaModule> moduleTussen = new List<AgendaModule>();
            for (int i = 0; i < agendaModules.Count; i++)
            {
                if (agendaModules[i].eindDatum <= DateTime.Today)
                {
                    moduleTussen.Add(agendaModules[i]);
                }
            }
            return moduleTussen;
        }

        public List<Gebruiker> readGebruikers()
        {
            List<Gebruiker> gebruikers = nietInlog.getGebruikers();
            return gebruikers;
        }
    }
}
