﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Antwoorden;
namespace JPP.DAL.EF
{
    public class AdminSCEF : AdminHC
    {
        EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;
  
        /*Add in de databank bij vaste vragen een meegegeven object van type vaste vraag*/
        public VasteVraag createVastevraag(VasteVraag vastevraag)
        {
            dbcontext.vasteVragen.Add(vastevraag);
            dbcontext.SaveChanges();
            return vastevraag;
        }

        /*Delete in de databank bij vaste vragen op basis van ID*/
        public void deleteVastevraag(int id)
        {
            VasteVraag vastevraag = dbcontext.vasteVragen.Find(id);
            dbcontext.vasteVragen.Remove(vastevraag);
            dbcontext.SaveChanges();
        }

        /*Update in dbcontext de entry van de meegegeven vaste vraag en save changes*/
        public void wijzigVastevraag(VasteVraag vastevraag)
        {
            dbcontext.Entry(vastevraag).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        /*########################## De rest van de create, delete en update doen hetzelfde maar voor andere objecten*/

        public CentraleVraag createCentraleVraag(CentraleVraag centralevraag)
        {
            dbcontext.centraleVragen.Add(centralevraag);
            dbcontext.SaveChanges();
            return centralevraag;
        }

        public void deleteCentralevraag(int id)
        {
            CentraleVraag centralevraag = dbcontext.centraleVragen.Find(id);
            dbcontext.centraleVragen.Remove(centralevraag);
            dbcontext.SaveChanges();

        }

        public void wijzigCentralevraag(CentraleVraag centralevraag)
        {
            dbcontext.Entry(centralevraag).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

        }

        public void setBeginDatumAgendaModule(DateTime startmoment, int id)
        {
            Module module = dbcontext.modules.Find(id);
            module.beginDatum = startmoment;
            dbcontext.Entry(module).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void setEindDatumAgendaModule(DateTime eindmoment, int id)
        {
            Module module = dbcontext.modules.Find(id);
            module.eindDatum = eindmoment;
            dbcontext.Entry(module).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void wijzigBeginDatumAgendaModule(DateTime startmoment, int id)
        {
            Module module = dbcontext.modules.Find(id);
            module.beginDatum = startmoment;
            dbcontext.Entry(module).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void wijzigEindDatumAgendaModule(DateTime eindmoment, int id)
        {
            Module module = dbcontext.modules.Find(id);
            module.eindDatum = eindmoment;
            dbcontext.Entry(module).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }


        public void deleteAgendaAntwoord(int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            dbcontext.antwoord.Remove(antwoord);
            dbcontext.SaveChanges();
        }

        public void wijzigAgendaAntwoord(AgendaAntwoord agendaAntwoord)
        {
            dbcontext.Entry(agendaAntwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void deleteDossierAntwoord(int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            dbcontext.antwoord.Remove(antwoord);
            dbcontext.SaveChanges();
        }

        public void wijzigDossierAntwoord(DossierAntwoord dossierAntwoord)
        {
            dbcontext.Entry(dossierAntwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        /*Vindt antwoord op basis van id en verander de volledigheidspercentage door de meegegeven parameter*/
     

        public void stelInVolledigheidsPercentage(int volledigheidsPercentage, int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            DossierAntwoord dosantwoord = (DossierAntwoord)antwoord;
            dosantwoord.percentageVolledigheid = volledigheidsPercentage;
            dbcontext.Entry(antwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        /*Het is belangrijk ook de relaties te onderhouden, bij maakdossier moet ook de bijbehorende beloning van type beloning, thema en centralevraag worden ingevuld*/

        public DossierModule maakDossierModule(DossierModule dossierModule)
        {



          //  dbcontext.vasteVragen.AddRange(dossierModule.vasteVragen);
           
            dbcontext.centraleVragen.Add(dossierModule.centraleVraag);
            dbcontext.themas.Add(dossierModule.thema);
            dbcontext.beloningen.Add(dossierModule.beloning);
            
            dbcontext.modules.Add(dossierModule);
            
            dbcontext.SaveChanges();
            return dossierModule;
        }
         /*Het is belangrijk ook de relaties te onderhouden, bij de rest gebeurt hetzelfde maar dan voor de bijbehorende relaties*/
        public AgendaModule maakAgendaModule(AgendaModule agendaModule)
        {



            //  dbcontext.vasteVragen.AddRange(dossierModule.vasteVragen);

            dbcontext.centraleVragen.Add(agendaModule.centraleVraag);
            dbcontext.themas.Add(agendaModule.thema);
            dbcontext.beloningen.Add(agendaModule.beloning);

            dbcontext.modules.Add(agendaModule);

            dbcontext.SaveChanges();
            return agendaModule;
        }

        public void wijzigDossierModule(DossierModule dossierModule)
        {

            DossierModule oldDossiermodule = (DossierModule)dbcontext.modules.Find(dossierModule.ID);
        
            dbcontext.Entry(oldDossiermodule.thema).CurrentValues.SetValues(dossierModule.thema);
            dbcontext.Entry(oldDossiermodule.beloning).CurrentValues.SetValues(dossierModule.beloning);
            dbcontext.Entry(oldDossiermodule.centraleVraag).CurrentValues.SetValues(dossierModule.centraleVraag);
            dbcontext.Entry(oldDossiermodule).CurrentValues.SetValues(dossierModule);

            dbcontext.SaveChanges();
        }

        public void wijzigAgendaModule(AgendaModule agendaModule)
        {

            AgendaModule oldAgendamodule = (AgendaModule)dbcontext.modules.Find(agendaModule.ID);
         
            dbcontext.Entry(oldAgendamodule.thema).CurrentValues.SetValues(agendaModule.thema);
            dbcontext.Entry(oldAgendamodule.beloning).CurrentValues.SetValues(agendaModule.beloning);
            dbcontext.Entry(oldAgendamodule.centraleVraag).CurrentValues.SetValues(agendaModule.centraleVraag);
            dbcontext.Entry(oldAgendamodule).CurrentValues.SetValues(agendaModule);

            dbcontext.SaveChanges();
        }

        public void deleteDossierModule(int id)
        {
            DossierModule dossierModule = (DossierModule)dbcontext.modules.Find(id);
            dbcontext.beloningen.Remove(dossierModule.beloning);
            dbcontext.themas.Remove(dossierModule.thema);
           
            dbcontext.centraleVragen.Remove(dossierModule.centraleVraag);
            dbcontext.vasteVragen.Remove(dossierModule.vasteVraagEen);

            dbcontext.antwoord.RemoveRange(dossierModule.dossierAntwoorden);
            dbcontext.modules.Remove(dossierModule);
            dbcontext.SaveChanges();
        }

        public void deleteAgendaModule(int id)
        {
            AgendaModule agendaModule = (AgendaModule)dbcontext.modules.Find(id);
            dbcontext.antwoord.RemoveRange(agendaModule.agendaAntwoorden);
            dbcontext.centraleVragen.Remove(agendaModule.centraleVraag);
            dbcontext.beloningen.Remove(agendaModule.beloning);
            dbcontext.themas.Remove(agendaModule.thema);
            dbcontext.modules.Remove(agendaModule);
            dbcontext.SaveChanges();
        }
    }
}
