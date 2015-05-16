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
   public class ModeratorSCEF : IngelogdeGebruikerSCEF, ModeratorHC
    {
       EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;
    
        public Tag createTag(Tag tag)
        {
            dbcontext.tags.Add(tag);
            dbcontext.SaveChanges();
            return tag;
        }

        public void deletePersoonlijkeTag(int ID)
        {
            Tag tag = dbcontext.tags.Find(ID);
            dbcontext.tags.Remove(tag);
            dbcontext.SaveChanges();
        }

        public void DeleteTag(int ID)
        {
            Tag tag = dbcontext.tags.Find(ID);
            dbcontext.tags.Remove(tag);
            dbcontext.SaveChanges();
        }

        public void AlterTag(Tag tag)
        {
            dbcontext.Entry(tag).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void setInactiefGebruiker(int ID)
        {
            Gebruiker gebruiker = dbcontext.gebruiker.Find(ID);
            gebruiker.active = false;
            dbcontext.Entry(gebruiker).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void setActiefGebruiker(int ID)
        {
            Gebruiker gebruiker = dbcontext.gebruiker.Find(ID);
            gebruiker.active = true;
            dbcontext.Entry(gebruiker).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
