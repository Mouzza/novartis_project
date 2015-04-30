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
        
        Tag createTag(Tag tag);
        void deletePersoonlijkeTag(int ID);
        void DeleteTag(int ID);
        void AlterTag(Tag tag);

        void setInactiefGebruiker(int ID);
        void setActiefGebruiker(int ID);
         
    }
}
