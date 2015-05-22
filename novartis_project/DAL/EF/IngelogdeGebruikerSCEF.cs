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

       /*Add in de databank bij DossierAntwoord een meegegeven object van type dossierAntwoord*/

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

       /*Geef Alle antwoorden van het type dossierAntwoord terug in een list. De databank houdt in antwoord de discriminator bij. 
        * Deze aproach is volgens ons een performantere aproach dan simpel 2 verschillende databanken te maken met 80% dezelfde kolommen*/

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
