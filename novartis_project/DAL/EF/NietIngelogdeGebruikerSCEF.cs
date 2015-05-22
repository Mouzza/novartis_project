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
    public class NietIngelogdeGebruikerSCEF
    {
        /* Indien dit onduidelijk is wordt dit uitgelegd in AdminSCEF en NietIngelogdeGebruikerSCEF*/
        public static EFDbContext dbcontext = new EFDbContext();
       
        public Organisatie getOrganisatie(int ID)
        {
            Organisatie organ = dbcontext.organisaties.Find(ID);
            return organ;
        }

        public Beloning getBeloning(int ID)
        {
            Beloning bel = dbcontext.beloningen.Find(ID);
            return bel;
        }

        public Thema getThema(int ID)
        {
            Thema thema = dbcontext.themas.Find(ID);
            return thema;
        }


        public CentraleVraag getCentraleVraag(int ID)
        {
            CentraleVraag cvraag = dbcontext.centraleVragen.Find(ID);
            return cvraag;
        }

        public VasteVraag getVasteVraag(int ID)
        {
            VasteVraag vvraag = dbcontext.vasteVragen.Find(ID);
            return vvraag;
        }



        public Antwoord getAntwoord(int ID)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(ID);
            return antwoord;
        }

        public DossierAntwoord getDossierAntwoord(int ID)
        {
            DossierAntwoord antwoord = (DossierAntwoord)dbcontext.antwoord.Find(ID);
            return antwoord;
        }

        public AgendaAntwoord getAgendaAntwoord(int ID)
        {
            AgendaAntwoord antwoord = (AgendaAntwoord)dbcontext.antwoord.Find(ID);
            return antwoord;
        }


        public IEnumerable<DossierAntwoord> getDossierAntwoorden()
        {
            return dbcontext.antwoord.OfType<DossierAntwoord>().ToList();
        }

        public IEnumerable<AgendaAntwoord> getAgendaAntwoorden()
        {
            return dbcontext.antwoord.OfType<AgendaAntwoord>().ToList();
        }


        public VasteTag getVasteTag(int ID)
        {
            VasteTag vasteTag = dbcontext.tags.Find(ID);
            return vasteTag;
        }

  

        public List<Comment> getAllComments()
        {
            List<Comment> comment = dbcontext.comments.ToList();
            return comment;
        }

        public Comment getComment(int ID)
        {
            Comment comment = dbcontext.comments.Find(ID);
            return comment;
        }

        public List<Module> getModules()
        {
            List<Module> module = dbcontext.modules.ToList();
            return module;
        }

        public Module getModule(int id)
        {
            Module module = dbcontext.modules.Find(id);
            return module;
        }

        public List<DossierModule> getDossierModules()
        {
            List<DossierModule> dossierModule = dbcontext.modules.OfType<DossierModule>().ToList();
            return dossierModule;
        }
        

        public List<AgendaModule> getAgendaModules()
        {
            List<AgendaModule> agendaModules = dbcontext.modules.OfType<AgendaModule>().ToList();
            return agendaModules;
        }

        //public List<DossierModule> getDossierModules()
        //{
        //    List<DossierModule> dossierModule = dbcontext.modules.OfType<DossierModule>().ToList();
        //    return dossierModule;
        //}

        //public List<AgendaModule> getAgendaModules()
        //{
        //    List<AgendaModule> agendaModules = dbcontext.modules.OfType<AgendaModule>().ToList();
        //    return agendaModules;
        //}
    }
}


