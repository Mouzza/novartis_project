using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Gebruikers.SuperUser;
using JPP.BL.Domain.Gebruikers.Beheerder;
using System.Configuration;

namespace JPP.DAL.EF
{
   public class MedebeheerderSCEF : MedebeheerderHC
    {
       EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;
        public void deleteAntwoord(int id)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(id);
            dbcontext.antwoord.Remove(antwoord);
            dbcontext.SaveChanges();
        }
        public void wijzigDossierAntwoord(DossierAntwoord dossierAntwoord)
        {
            DossierAntwoord oldDossierAntwoord = (DossierAntwoord)dbcontext.antwoord.Find(dossierAntwoord.ID);
            dbcontext.Entry(oldDossierAntwoord).CurrentValues.SetValues(dossierAntwoord);
            dbcontext.SaveChanges();
        }
        public void wijzigAgendaAntwoord(AgendaAntwoord agendeaAntwoord)
        {
            dbcontext.Entry(agendeaAntwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
