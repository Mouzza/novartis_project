﻿using System;
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
    public class EFDbInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
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
                    inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg",
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    aantalStemmen = 20,
                    percentageVolledigheid = 95,
                    statusOnline = true,
                    extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?",
                    aantalFlags = 0,
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>()


                };
           
                dossierModule.dossierAntwoorden.Add(dossierAntwoord);

                //Tags
                //tag.antwoorden.Add(dossierAntwoord);
                //pTag.antwoorden.Add(dossierAntwoord);

                //DossierAntwoord
                dossierAntwoord.module = dossierModule;
                //dossierAntwoord.vasteTags.Add(tag);
                //dossierAntwoord.persoonlijkeTags.Add(pTag);

            }

            vasteVraagAntwoord.vasteVraag = vasteVraag;
            vasteVraag.vasteVraagAntwoorden.Add(vasteVraagAntwoord);

         
        
            //DossierModule
            dossierModule.beloning.Add(beloning);
            dossierModule.thema = thema;
            dossierModule.centraleVraag = centraleVraag;
            dossierModule.vasteVragen.Add(vasteVraag);
            dossierModule.organisatie = organisatieLeuven;
            organisatieLeuven.modules.Add((Module)dossierModule);
       
          

         
            context.modules.Add(dossierModule);
         
 

            context.SaveChanges();

        }
        
    }
   
}
