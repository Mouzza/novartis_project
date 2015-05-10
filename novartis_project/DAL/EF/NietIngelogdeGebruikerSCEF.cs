using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Gebruikers.SuperUser;
using JPP.BL.Domain.Gebruikers.Beheerder;
using System.Configuration;

namespace JPP.DAL.EF
{
    public class NietIngelogdeGebruikerSCEF
    {
        EFDbContext dbcontext;
        public NietIngelogdeGebruikerSCEF()
        {
            dbcontext = new EFDbContext();
        }
        public Gebruiker createGebruiker(Gebruiker gebruiker)
        {
            dbcontext.gebruiker.Add(gebruiker);
            dbcontext.SaveChanges();
            return gebruiker;
        }

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

        public Voorstel getVoorstel(int ID)
        {
            Voorstel voorstel = dbcontext.voorstellen.Find(ID);
            return voorstel;
        }


        public Antwoord getAntwoord(int ID)
        {
            Antwoord antwoord = dbcontext.antwoord.Find(ID);
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

        public Gebruiker getGebruiker(int ID)
        {
            Gebruiker gebruiker = dbcontext.gebruiker.Find(ID);
            return gebruiker;
        }

        public Moderator getModerator(int ID)
        {
            Moderator moderator = dbcontext.moderator.Find(ID);
            return moderator;
        }


        public Beheerder getBeheerder(int ID)
        {
            Beheerder beheerder = dbcontext.beheerder.Find(ID);
            return beheerder;
        }

        public Medebeheerder getMedebeheerder(int ID)
        {
            Medebeheerder medebeheerder = dbcontext.medebeheerder.Find(ID);
            return medebeheerder;
        }

        public Expert getExpert(int ID)
        {
            Expert expert = dbcontext.expert.Find(ID);
            return expert;
        }

        public Admin getAdmin(int ID)
        {
            Admin admin = dbcontext.admin.Find(ID);
            return admin;
        }

        public SuperAdmin getSuperAdmin(int ID)
        {
            SuperAdmin superAdmin = dbcontext.superAdmin.Find(ID);
            return superAdmin;
        }


        public Tag getTag(int ID)
        {
            Tag tag = dbcontext.tags.Find(ID);
            return tag;
        }


        public PersoonlijkeTag getPersoonlijkeTag(int ID)
        {
            PersoonlijkeTag persoonlijkeTag = dbcontext.tags.OfType<PersoonlijkeTag>().Where(tag => tag.ID == ID).First();
            return persoonlijkeTag;
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
<<<<<<< HEAD
            List<Module> antwoordlist = dbcontext.modules.ToList();
            List<DossierModule> AgendaAntwoordList = new List<DossierModule>();
            DossierModule agmod = new DossierModule();
            foreach(var antwoord in antwoordlist){
                if (antwoord is DossierModule)
                {
                    AgendaAntwoordList.Add((DossierModule)antwoord);
                }
=======
            //List<Module> antwoordlist = dbcontext.modules.ToList();
            //List<DossierModule> AgendaAntwoordList = new List<DossierModule>();
            //DossierModule agmod = new DossierModule();
            //foreach(var antwoord in antwoordlist){
            //    if (antwoord.GetType() == agmod.GetType())
            //    {
            //        AgendaAntwoordList.Add((DossierModule)antwoord);
            //    }
>>>>>>> origin/master
                
            //}
            //return AgendaAntwoordList;
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


