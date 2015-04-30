using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using JPP.Domain;


namespace JPP.DAL.EF
{
    public class EFDbInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {

            VasteVraagAntwoord vasteVraagAntwoord = new VasteVraagAntwoord(){
                inhoud="Zorgt voor een positieve en gezonde bezigheid voor de buurtbewoners.",
                extraInfo ="Hopelijk wordt dit gerealizeerd, wij kijken er al vanuit",
                datum = DateTime.Now
            };
            VasteVraag vasteVraag = new VasteVraag()
            {

             
                inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?",
                extraInfo = "Dit is extra info en is verplicht in te vullen",
                verplicht = true,
                vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

            };
          
            CentraleVraag centraleVraag = new CentraleVraag()
            {
                    inhoud="Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?",
                    extraInfo="Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum= new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 1
                   

            };
            Thema thema = new Thema()
            {
                inhoud="Sport",
                dossierModules = new List<Dossiermodule>(),
                agendaModules = new List<Agendamodule>()
             
            };
            Beloning beloning = new Beloning()
            {
                naam="Reis naar barcelona",
                beschrijving="Win een reis naar barcelona!",
                dossierModules = new List<Dossiermodule>(),
                agendaModules = new List<Agendamodule>()


            };
            
          


            Dossiermodule dossierModule = new Dossiermodule()
            {

                AdminNaam = "azaz5",
                naam = "Rivierenhof categorie",
                beginDatum= new DateTime(2015, 9, 10, 15, 5, 59),
                eindDatum= new DateTime(2015, 10, 10, 15, 5, 59),
                volledigheidsPercentage = 90.5,
                vasteVragen = new List<VasteVraag>(),
                dossierAntwoorden = new List<DossierAntwoord>(),
                status = ModuleStatus.Open


            };

            PersoonlijkeTag pTag = new PersoonlijkeTag()
            {

                inhoud = "Fun!",
                dossierAntwoorden = new List<DossierAntwoord>(),
                agendaAntwoorden = new List<AgendaAntwoord>(),
                voorstellen = new List<Voorstel>()
            };

            Tag tag = new Tag()
            {

                inhoud = "Sport",
                dossierAntwoorden = new List<DossierAntwoord>(),
                agendaAntwoorden = new List<AgendaAntwoord>(),
                voorstellen = new List<Voorstel>()
            };


            for (int i = 0; i < 32; i++)
            {
                DossierAntwoord dossierAntwoord = new DossierAntwoord()
                {

                    gebruikerNaam = "Admin",
                    expertNaam = "zaz56",
                    inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg",
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    aantalStemmen = 20,
                    percentageVolledigheid = 95,
                    statusOnline = true,
                    extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?",
                    aantalFlags = 0,
                    comments = new List<Comment>(),
                    tags = new List<Tag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>()


                };
                dossierModule.dossierAntwoorden.Add(dossierAntwoord);

                //Tags
                tag.dossierAntwoorden.Add(dossierAntwoord);
                pTag.dossierAntwoorden.Add(dossierAntwoord);

                //DossierAntwoord
                dossierAntwoord.dossierModule = dossierModule;
                dossierAntwoord.tags.Add(tag);
                dossierAntwoord.persoonlijkeTags.Add(pTag);

            }

            //vasteVraagAntwoord.vasteVraag = vasteVraag;
            vasteVraag.vasteVraagAntwoorden.Add(vasteVraagAntwoord);
            
        
            //DossierModule
            dossierModule.beloning = beloning;
            dossierModule.thema = thema;
            dossierModule.centraleVraag = centraleVraag;

           
       
            dossierModule.vasteVragen.Add(vasteVraag);

         
            context.dossiermodules.Add(dossierModule);
         
 

            context.SaveChanges();

        }
    }
   
}
