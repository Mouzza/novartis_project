using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using JPP.BL.Domain;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;


namespace JPP.DAL.EF
{
    public class EFDbInitializer : CreateDatabaseIfNotExists<EFDbContext>
    {
       protected override void Seed(EFDbContext context)
        {

            VasteVraagAntwoord vasteVraagAntwoord = new VasteVraagAntwoord()
            {
                inhoud="Zorgt voor een positieve en gezonde bezigheid voor de buurtbewoners.",  
            };
            VasteVraag vasteVraag = new VasteVraag()
            {

             
                inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?",
                extraInfo = "Dit is extra info en is verplicht in te vullen",

                boolVerplicht = true,
                vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

            };
          
            CentraleVraag centraleVraag = new CentraleVraag()
            {
                    inhoud="Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?",
                    extraInfo="Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum= new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 1
                   

            };

            CentraleVraag centraleVraag2 = new CentraleVraag()
            {
                inhoud = "Deel u idee mee, wat zou er veranderd worden in de hogeschool?",
                extraInfo = "Wij zijn op zoek naar ideen, deel uw idee met ons en maak kans op prijzen!",
                datum = new DateTime(2015, 9, 10, 15, 5, 59),
                aantalWinAntwoorden = 1


            };
            Thema thema = new Thema()
            {
                naam="Sport",
               
                modules = new List<Module>()
         
             
            };
            Beloning beloning = new Beloning()
            {
                naam="Reis naar barcelona",
                beschrijving="Win een reis naar barcelona!",
                modules = new List<Module>()


            };
          
            DossierModule dossierModule = new DossierModule()
            {
                beloning = new List<Beloning>(),    
                adminNaam = "Admin",
                naam = "Rivierenhof categorie",
                beginDatum= new DateTime(2014, 03, 10, 15, 5, 59),
                eindDatum= new DateTime(2018, 10, 10, 15, 5, 59),
                verplichteVolledigheidsPercentage = 90.5,
                vasteVragen = new List<VasteVraag>(),
                dossierAntwoorden = new List<DossierAntwoord>(),
                status = true


            };
            AgendaModule agendaModule = new AgendaModule()
            {
                beloning = new List<Beloning>(),
                adminNaam = "Admin",
                naam = "Rivierenhof categorie",
                beginDatum = new DateTime(2014, 03, 10, 15, 5, 59),
                eindDatum = new DateTime(2018, 10, 10, 15, 5, 59),
                agendaAntwoorden = new List<AgendaAntwoord>(),
                status = true


            };

            PersoonlijkeTag pTag = new PersoonlijkeTag()
            {

                naam = "Fun!",
                antwoorden = new List<Antwoord>(),
                voorstellen = new List<Voorstel>()
            };

            VasteTag tag = new VasteTag()
            {

                naam = "Sport",
                antwoorden = new List<Antwoord>(),
          
                voorstellen = new List<Voorstel>()
            };

            Organisatie organisatieLeuven = new Organisatie()
            {
                naam = "JPP",
                gemeente = "Leuven",
                modules = new List<Module>()

            };
            for (int i = 0; i < 32; i++)
            {
               
                DossierAntwoord dossierAntwoord = new DossierAntwoord()
                {

                
                   gebruikersNaam = "Gebruiker01",
                    inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg, antw nummer: " + i,
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    aantalStemmen = i,
                    percentageVolledigheid = 95,
                    statusOnline = true,
                    extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?",
                    aantalFlags = 0,
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>()


                };

                AgendaAntwoord agendaAntwoord = new AgendaAntwoord()
                {


                    gebruikersNaam = "Gebruiker01",
                    inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg, antw nummer: " + i,
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    aantalStemmen = i,             
                    aantalFlags = 0,
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>()


                };
                agendaModule.agendaAntwoorden.Add(agendaAntwoord);
                agendaAntwoord.module = agendaModule;
                dossierModule.dossierAntwoorden.Add(dossierAntwoord);
                dossierAntwoord.module = dossierModule;
                //Tags
                //tag.antwoorden.Add(dossierAntwoord);
                //pTag.antwoorden.Add(dossierAntwoord);

                //DossierAntwoord
        
                //dossierAntwoord.vasteTags.Add(tag);
                //dossierAntwoord.persoonlijkeTags.Add(pTag);

            }

            vasteVraagAntwoord.vasteVraag = vasteVraag;
            vasteVraag.vasteVraagAntwoorden.Add(vasteVraagAntwoord);



            //geplande modules
            int jaar = 2015;
            int jaar2 = 2016;
            for (int x = 0; x < 10; x++)
            {
          
                jaar+=1;
                jaar2+=1;

                DossierModule geplandeDossierModule = new DossierModule()
                {
                    beloning = new List<Beloning>(),
                    adminNaam = "Admin",
                    naam = "Rivierenhof speeltuin",
                    beginDatum = new DateTime(jaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(jaar2, 10, 10, 15, 5, 59),
                    verplichteVolledigheidsPercentage = 90.5,
                    vasteVragen = new List<VasteVraag>(),
                    dossierAntwoorden = new List<DossierAntwoord>(),
                    status = false


                };
                geplandeDossierModule.beloning.Add(beloning);
                geplandeDossierModule.centraleVraag = centraleVraag;
                geplandeDossierModule.thema = thema;
                geplandeDossierModule.organisatie = organisatieLeuven;
                geplandeDossierModule.vasteVragen.Add(vasteVraag);
                context.modules.Add(geplandeDossierModule);


                AgendaModule geplandeAgendaModule = new AgendaModule()
                {
                    beloning = new List<Beloning>(),
                    adminNaam = "Admin",
                    naam = "Hoe creatief ben jij?!",
                    beginDatum = new DateTime(jaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(jaar2, 10, 10, 15, 5, 59),
                    agendaAntwoorden = new List<AgendaAntwoord>(),
                    status = false


                };
                geplandeAgendaModule.centraleVraag = centraleVraag2;
                geplandeAgendaModule.beloning.Add(beloning);
                geplandeAgendaModule.thema = thema;
                geplandeAgendaModule.organisatie = organisatieLeuven;
                context.modules.Add(geplandeAgendaModule);

                

            }

        
            //DossierModule
            dossierModule.beloning.Add(beloning);
            dossierModule.thema = thema;
            dossierModule.centraleVraag = centraleVraag;
            dossierModule.vasteVragen.Add(vasteVraag);
            dossierModule.organisatie = organisatieLeuven;
            organisatieLeuven.modules.Add((Module)dossierModule);
       
           //AgendaModule

            agendaModule.beloning.Add(beloning);
            agendaModule.thema = thema;
            agendaModule.organisatie = organisatieLeuven;
            agendaModule.centraleVraag = centraleVraag2;

         
            context.modules.Add(dossierModule);
            context.modules.Add(agendaModule);
            
            context.SaveChanges();

        }
        
    }
   
}
