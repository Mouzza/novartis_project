using JPP.BL.Domain.Antwoorden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL
{
    public interface IStemManager
    {
        Stem stemOpAntwoord(Stem stem);
    }
}
