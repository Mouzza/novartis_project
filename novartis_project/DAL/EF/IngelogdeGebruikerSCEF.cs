using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using System.Configuration;


namespace JPP.DAL.EF
{
   public class IngelogdeGebruikerSCEF : NietIngelogdeGebruikerSCEF, IngelogdeGebruikerHC
    {
       EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;



        /*
        public Antwoord maakAntwoord(Antwoord antwoord)
        {
            // throw new NotImplementedException();
        }
         * */

        public DossierAntwoord maakDossierAntwoord(DossierAntwoord dossierAntwoord)
        {

                dbcontext.antwoord.Add(dossierAntwoord);
                dbcontext.SaveChanges();
                return dossierAntwoord;

        }

        public AgendaAntwoord maakAgendaAntwoord(AgendaAntwoord agendaAntwoord)
        {
            dbcontext.antwoord.Add(agendaAntwoord);
            dbcontext.SaveChanges();
            return agendaAntwoord;
        }

        public List<DossierAntwoord> getAllDossierAntwoorden()
        {
         
            return dbcontext.antwoord.OfType<DossierAntwoord>().ToList();
        }
        public List<Antwoord> getAllAntwoorden()
        {

            return dbcontext.antwoord.ToList();
        }
        public List<AgendaAntwoord> getAllAgendaAntwoorden()
        {
            return dbcontext.antwoord.OfType<AgendaAntwoord>().ToList();
        }

        public Stem createStem(Stem stem)
        {
            dbcontext.stemmen.Add(stem);
            dbcontext.SaveChanges();
            return stem;
        }

        public Flag createFlag(Flag flag)
        {
            dbcontext.flags.Add(flag);
            dbcontext.SaveChanges();
            return flag;
        }




       
    }
}
