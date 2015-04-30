using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Vragen
{
    public class CentraleVraag
    {

        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public int aantalWinAntwoorden { get; set; }

        [Key, ForeignKey("module")]
        public int moduleID { get; set; }
        public virtual Module module { get; set; }

    }
}
