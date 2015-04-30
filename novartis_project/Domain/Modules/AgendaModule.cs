using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;

namespace JPP.BL.Domain.Modules
{
    public class AgendaModule:Module
    {
        public virtual ICollection<AgendaAntwoord> agendaAntwoorden { get; set; }
    }
}
