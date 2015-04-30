using JPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.DAL.EF
{
    public class AntwoordMapper : IAntwoordMapper
    {

        EFDbContext dbcontext;

        public AntwoordMapper()
        {

            dbcontext = new EFDbContext();
        }




        public DossierAntwoord ReadDossierAntwoord(int id)
        {
           return dbcontext.dossierAntwoorden.Find(id);
        }

        public AgendaAntwoord ReadAgendaAntwoord(int id)
        {
            return dbcontext.agendaAntwoorden.Find(id);
        }

        public IEnumerable<DossierAntwoord> ReadAllDossierAntwoorden()
        {
            return dbcontext.dossierAntwoorden.ToList();
        }

        public IEnumerable<AgendaAntwoord> ReadAllAgendaAntwoorden()
        {
            return dbcontext.agendaAntwoorden.ToList();
        }

        public IEnumerable<DossierAntwoord> ReadDossierAntwoorden(int dossierId)
        {
            Dossiermodule dossiermodule = dbcontext.dossiermodules.Find(dossierId);

            return dossiermodule.dossierAntwoorden;
        }

        public IEnumerable<AgendaAntwoord> ReadAgendaAntwoorden(int agendaId)
        {
            throw new NotImplementedException();

            //Agendamodule agendamodule = dbcontext.agendamodules.Find(agendaId);

            //return agendamodule.dossierAntwoorden;
        }
    }
}
