
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;

namespace JPP.DAL.EF
{
    public interface IModuleMapper
    {
        DossierModule ReadDossiermodule(int id);
        AgendaModule ReadAgendamodule(int id);

        void DeleteDossiermodule(int id);
        void DeleteAgendamodule(int id);

        void UpdateDossiermodule(DossierModule dossiermodule);
        void UpdateAgendamodule(AgendaModule agendamodule);

        IEnumerable<DossierModule> ReadAllDossiermodules();
        IEnumerable<AgendaModule> ReadAllAgendamodules();
        DossierModule CreateDossiermodule(DossierModule dossiermodule);
        AgendaModule CreateAgendamodule(AgendaModule agendamodule);
    }
}

