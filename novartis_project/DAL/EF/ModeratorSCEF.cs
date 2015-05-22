using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using System.Configuration;

namespace JPP.DAL.EF
{
   public class ModeratorSCEF : IngelogdeGebruikerSCEF, ModeratorHC
    {
       EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;
       /* Indien dit onduidelijk is wordt dit uitgelegd in AdminSCEF */
        public VasteTag CreateVasteTag(VasteTag vasteTag)
        {
            dbcontext.tags.Add(vasteTag);
            dbcontext.SaveChanges();
            return vasteTag;
        }

 
        public void DeleteVasteTag(int ID)
        {
            VasteTag vasteTag = dbcontext.tags.Find(ID);
            dbcontext.tags.Remove(vasteTag);
            dbcontext.SaveChanges();
        }

        public void AlterVasteTag(VasteTag vasteTag)
        {
            VasteTag oldVasteTag = (VasteTag)dbcontext.tags.Find(vasteTag.ID);
            dbcontext.Entry(oldVasteTag).CurrentValues.SetValues(vasteTag);
      
            dbcontext.SaveChanges();
        }

        public List<VasteTag> GetAllVasteTags()
        {
            return dbcontext.tags.ToList();
  
        }
        public VasteTag GetVasteTag(int id)
        {
            return dbcontext.tags.Find(id);

        }

      
    }
}
