﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Vragen;


namespace JPP.DAL.Interface
{
    public interface ModeratorHC
    {
        /* Interfaceklassen voor de EF klassen */
        
        VasteTag CreateVasteTag(VasteTag vasteTag);
        void DeleteVasteTag(int ID);
        void AlterVasteTag(VasteTag vasteTag);
        VasteTag GetVasteTag(int id);
        List<VasteTag> GetAllVasteTags();
    }
}
