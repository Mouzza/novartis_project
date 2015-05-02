using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.DAL.EF
{
    public class AdminSCEF : AdminHC
    {
        public AdminSCEF()
        {
            dbcontext=new EFDbContext();
        }

        EFDbContext dbcontext;
        public VasteVraag createVastevraag(VasteVraag vastevraag)
        {
            dbcontext.vasteVragen.Add(vastevraag);
            dbcontext.SaveChanges();
            return vastevraag;
        }

        public void deleteVastevraag(int id)
        {
            VasteVraag vastevraag = dbcontext.vasteVragen.Find(id);
            dbcontext.vasteVragen.Remove(vastevraag);
            dbcontext.SaveChanges();
        }

        public void wijzigVastevraag(VasteVraag vastevraag)
        {
            dbcontext.Entry(vastevraag).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

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

        public void stelInAantalStemmen(int aantalstemmen, int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            antwoord.aantalStemmen = aantalstemmen;
            dbcontext.Entry(antwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

        }

        public void stelInVolledigheidsPercentage(int volledigheidsPercentage, int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            DossierAntwoord dosantwoord = (DossierAntwoord)antwoord;
            dosantwoord.percentageVolledigheid = volledigheidsPercentage;
            dbcontext.Entry(antwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public Expert setExpert(Expert expert)
        {
            dbcontext.expert.Add(expert);
            dbcontext.SaveChanges();
            return expert;
        }

        public void deleteExpert(int id)
        {
            Expert expert = dbcontext.expert.Find(id);
            dbcontext.expert.Remove(expert);
            dbcontext.SaveChanges();

        }

        public void wijzigExpert(Expert expert)
        {
            dbcontext.Entry(expert).State = System.Data.Entity.EntityState.Modified;
        }

        public Moderator setModerator(Moderator moderator)
        {
            dbcontext.moderator.Add(moderator);
            dbcontext.SaveChanges();
            return moderator;
        }

        public void deleteModerator(int id)
        {
            Moderator moderator = dbcontext.moderator.Find(id);
            dbcontext.moderator.Remove(moderator);
            dbcontext.SaveChanges();

        }

        public void wijzigModerator(Moderator moderator)
        {
            dbcontext.Entry(moderator).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public Module createModule(Module module)
        {
            dbcontext.modules.Add(module);
            dbcontext.SaveChanges();
            return module;
        }

        public void wijzigModule(Module module)
        {
            dbcontext.Entry(module).State = System.Data.Entity.EntityState.Modified;
            //alles met betrekken tot de module moet mee gewijzigd worden, bv thema, beloning enz
            dbcontext.Entry(module.thema).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void deleteModule(int id)
        {
            Module module = dbcontext.modules.Find(id);
            dbcontext.modules.Remove(module);
            dbcontext.SaveChanges();
        }
    }
}
