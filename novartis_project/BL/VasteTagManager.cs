using JPP.BL.Domain.Antwoorden;
using JPP.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL
{
    public class VasteTagManager : IVasteTagManager
    {

        ModeratorSCEF modSCEF = new ModeratorSCEF();

        public void removeVasteTag(int id)
        {
            modSCEF.DeleteVasteTag(id);
        }
        public VasteTag createVasteTag(VasteTag vasteTag)
        {
            return modSCEF.CreateVasteTag(vasteTag);
        }
        public void updateVasteTag(VasteTag vasteTag)
        {
            modSCEF.AlterVasteTag(vasteTag);
        }
        public List<VasteTag> readAllVasteTags()
        {
            return modSCEF.GetAllVasteTags();
        }

        public VasteTag readVasteTag(int id)
        {
            return modSCEF.GetVasteTag(id);
        }
    }
}
