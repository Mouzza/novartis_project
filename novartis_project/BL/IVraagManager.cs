using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Vragen;

namespace JPP.BL
{
    interface IVraagManager
    {
        VasteVraag maakVasteVraag(VasteVraag vasteVraag);
        void deleteVasteVraag(VasteVraag vasteVraag);
        void wijzigVasteVraag(VasteVraag vasteVraag);
        VasteVraag getVasteVraag(int ID);

        Voorstel maakVoorstel(Voorstel voorstel);
        void deleteVoorstel(Voorstel voorstel);
        void wijzigVoorstel(Voorstel voorstel);
        Voorstel getVoorstel(int ID);
    }
}
