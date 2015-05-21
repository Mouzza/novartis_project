using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Gebruikers;

namespace JPP.DAL.Interface
{
    public interface ModeratorHC
    {
        
        VasteTag CreateVasteTag(VasteTag vasteTag);
        void DeleteVasteTag(int ID);
        void AlterVasteTag(VasteTag vasteTag);
         
    }
}
