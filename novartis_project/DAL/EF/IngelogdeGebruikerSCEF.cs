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
   public class IngelogdeGebruikerSCEF : NietIngelogdeGebruikerSCEF, IngelogdeGebruikerHC
    {
        EFDbContext dbcontext;
        public IngelogdeGebruikerSCEF()
        {
            dbcontext = new EFDbContext();
        }

        public Beheerder createBeheerder(Beheerder gebruiker)
        {
            dbcontext.beheerder.Add(gebruiker);
            dbcontext.SaveChanges();
            return gebruiker;
        }


        public void deleteGebruiker(int id)
        {
            Gebruiker gebr = dbcontext.gebruiker.Find(id);
            dbcontext.gebruiker.Remove(gebr);
            dbcontext.SaveChanges();


        }

        public void wijzigGebruiker(Gebruiker gebruiker)
        {
            dbcontext.Entry(gebruiker).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        /*
        public Antwoord maakAntwoord(Antwoord antwoord)
        {
            // throw new NotImplementedException();
        }
         * */

        public DossierAntwoord maakDossierAntwoord(DossierAntwoord dossierAntwoord)
        {
            
            dbcontext.antwoord.Add(dossierAntwoord);
            dbcontext.SaveChanges();
            return dossierAntwoord;

        }

        public AgendaAntwoord maakAgendaAntwoord(AgendaAntwoord agendaAntwoord)
        {
            dbcontext.antwoord.Add(agendaAntwoord);
            dbcontext.SaveChanges();
            return agendaAntwoord;
        }

        public List<DossierAntwoord> getAllDossierAntwoorden()
        {
         
            return dbcontext.antwoord.OfType<DossierAntwoord>().ToList();
        }
        public List<AgendaAntwoord> getAllAgendaAntwoorden()
        {
            return dbcontext.antwoord.Cast<AgendaAntwoord>().ToList();
        }

        public Comment createComment(Comment comment)
        {
            dbcontext.comments.Add(comment);
            dbcontext.SaveChanges();
            return comment;
        }

        public void wijzigComment(Comment comment)
        {
            dbcontext.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void deleteComment(int id)
        {
            Comment comment = dbcontext.comments.Find(id);
            dbcontext.comments.Remove(comment);
            dbcontext.SaveChanges();
        }

        public void stemOpComment(int id)
        {
            Comment comment= dbcontext.comments.Find(id);
            comment.aantalStemmen++;
            dbcontext.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }


    }
}
