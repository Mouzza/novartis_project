using JPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.DAL.EF
{
    public class ModuleMapper : IModuleMapper
    {

        EFDbContext dbcontext;

        public ModuleMapper()
        {

            dbcontext = new EFDbContext();
        }

        public Dossiermodule ReadDossiermodule(int id)
        {
            Dossiermodule dossiermodule = dbcontext.dossiermodules.Find(id);

            return dossiermodule;
        }
        public Agendamodule ReadAgendamodule(int id)
        {
            Agendamodule agendamodule = dbcontext.agendamodules.Find(id);
            return agendamodule;
        }

        public void DeleteDossiermodule(int id)
        {
            Dossiermodule dossiermodule = dbcontext.dossiermodules.Find(id);

            dbcontext.centraleVragen.Remove(dossiermodule.centraleVraag);
            if(dossiermodule.dossierAntwoorden.Count > 0){
                 foreach (DossierAntwoord da in dossiermodule.dossierAntwoorden)
                    {
                        if (da.comments.Count>0)
                        {
                            dbcontext.comments.RemoveRange(da.comments);
                        }

                        if (da.evenement!=null)
                        {
                              dbcontext.evenementen.Remove(da.evenement);
                        }

                        if (da.persoonlijkeTags.Count > 0)
                        {
                        dbcontext.persoonlijkeTags.RemoveRange(da.persoonlijkeTags);
                        }

                        if (da.tags.Count > 0)
                        {
                            dbcontext.tags.RemoveRange(da.tags);
                        }

                    }

                 dbcontext.dossierAntwoorden.RemoveRange(dossiermodule.dossierAntwoorden);
             
            }

        
            if (dossiermodule.vasteVragen.Count > 0)
            {
                foreach (VasteVraag vv in dossiermodule.vasteVragen)
                {
                    if(vv.vasteVraagAntwoorden.Count > 1){
                        foreach(VasteVraagAntwoord vva in vv.vasteVraagAntwoorden){
                            dbcontext.vasteVraagAntwoorden.Remove(vva);
                        }

                    }
                    else if (vv.vasteVraagAntwoorden.Count == 1)
                    {
                        dbcontext.vasteVraagAntwoorden.Remove(vv.vasteVraagAntwoorden.FirstOrDefault());
                    }

            
                }
                dbcontext.vasteVragen.RemoveRange(dossiermodule.vasteVragen);
                
            }

   


            //dbcontext.beloningen.Remove(dossiermodule.beloning);
            //dbcontext.themas.Remove(dossiermodule.thema);

     

         
       
            dbcontext.dossiermodules.Remove(dossiermodule);
            dbcontext.SaveChanges();
        }
        public void DeleteAgendamodule(int id)
        {
            Agendamodule agendamodule = dbcontext.agendamodules.Find(id);
            dbcontext.agendamodules.Remove(agendamodule);
            dbcontext.SaveChanges();
        }

        public void UpdateDossiermodule(Dossiermodule dossiermodule)
        {

            Dossiermodule oldDossiermodule = dbcontext.dossiermodules.Find(dossiermodule.id);
            dbcontext.Entry(oldDossiermodule).CurrentValues.SetValues(dossiermodule);
            dbcontext.Entry(oldDossiermodule.thema).CurrentValues.SetValues(dossiermodule.thema);

            //dbcontext.Entry(dossiermodule.centraleVraag).State = System.Data.Entity.EntityState.Modified;

            //dbcontext.Entry(dossiermodule.beloning).State = System.Data.Entity.EntityState.Modified;
          
            //dbcontext.Entry(dossiermodule.thema).State = System.Data.Entity.EntityState.Modified;

            dbcontext.SaveChanges();
        }
        public void UpdateAgendamodule(Agendamodule agendamodule)
        {
            dbcontext.Entry(agendamodule).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public IEnumerable<Dossiermodule> ReadAllDossiermodules()
        {
            return dbcontext.dossiermodules.ToList();

        }
        public IEnumerable<Agendamodule> ReadAllAgendamodules()
        {
            return dbcontext.agendamodules.ToList();

        }

        public Dossiermodule CreateDossiermodule(Dossiermodule dossiermodule)
        {

            dbcontext.vasteVragen.AddRange(dossiermodule.vasteVragen);
            dbcontext.centraleVragen.Add(dossiermodule.centraleVraag);
            dbcontext.themas.Add(dossiermodule.thema);
            dbcontext.dossiermodules.Add(dossiermodule);
            dbcontext.SaveChanges();

            return dossiermodule;
        }
        public Agendamodule CreateAgendamodule(Agendamodule agendamodule)
        {
            dbcontext.agendamodules.Add(agendamodule);
            dbcontext.SaveChanges();

            return agendamodule;
        }
    }
}
