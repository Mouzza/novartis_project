using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Modules;

namespace JPP.BL
{
    interface IModuleManager
    {
       // List<Module> topModules(int top);
        Module readModule(int id);
        DossierModule readActieveDossierModule();
        AgendaModule readActieveAgendaModule();
        List<DossierModule> readAllDossierModules();
        List<AgendaModule> readAllAgendaModules();
        List<DossierModule> readGeslotenDossiers();
        List<AgendaModule> readGeslotenAgendas();
        List<Module> readGeplandeModules();
        DossierModule createDossierModule(DossierModule dossierModule);
        void updateModule(Module module);
        void removeModule(int id);
    }
}
