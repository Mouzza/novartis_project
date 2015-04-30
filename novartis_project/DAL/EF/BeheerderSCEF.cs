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
    public class BeheerderSCEF : MedebeheerderSCEF, BeheerderHC
    {

        EFDbContext dbcontext;
        public BeheerderSCEF()
        {
            dbcontext = new EFDbContext();
        }
        public Medebeheerder createMedeBeheerder(Medebeheerder medebeheerder)
        {

            dbcontext.medebeheerder.Add(medebeheerder);
            dbcontext.SaveChanges();
            return medebeheerder;
        }

        public void DeleteMedeBeheerder(int ID)
        {
            Medebeheerder medebeheerder = dbcontext.medebeheerder.Find(ID);
            dbcontext.medebeheerder.Remove(medebeheerder);
            dbcontext.SaveChanges();
        }

        public void WijzigMedeBeheerder(Medebeheerder medebeheerder)
        {
            dbcontext.Entry(medebeheerder).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public PersoonlijkeTag maakPersoonlijkeTag(PersoonlijkeTag persoonlijkeTag)
        {
            dbcontext.tags.Add(persoonlijkeTag);
            dbcontext.SaveChanges();
            return persoonlijkeTag;
        }

        public void deletePersoonlijkeTag(int id)
        {

            PersoonlijkeTag persoonlijketag = (PersoonlijkeTag) dbcontext.tags.Find(id);
            dbcontext.tags.Remove(persoonlijketag);
            dbcontext.SaveChanges();
        }

     /*   public void wijzigAgendaAntwoord(AgendaAntwoord agendeaAntwoord)
        {
            dbcontext.Entry(agendeaAntwoord).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }*/
    }
}
