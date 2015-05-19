using JPP.BL.Domain.Antwoorden;
using JPP.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL
{
    public class StemManager : IStemManager
    {

        IngelogdeGebruikerSCEF inlog;

        public StemManager()
        {
            inlog = new IngelogdeGebruikerSCEF();
     
        }


        public Stem stemOpAntwoord(Stem stem)
        {
           return inlog.createStem(stem);
        } 
    }
}
