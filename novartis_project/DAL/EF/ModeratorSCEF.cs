﻿using System;
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
            dbcontext.Entry(vasteTag).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

      
    }
}
