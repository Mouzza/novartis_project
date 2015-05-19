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


            #region actieve modules

            VasteVraagAntwoord vasteVraagAntwoord1 = new VasteVraagAntwoord()
            {
                inhoud = "Zorgt voor een positieve en gezonde bezigheid voor de buurtbewoners.",
            };

            VasteVraagAntwoord vasteVraagAntwoord2 = new VasteVraagAntwoord()
            {
                inhoud = "Zorgt voor een positieve en gezonde bezigheid voor de buurtbewoners.",
            };
            VasteVraag vasteVraag1 = new VasteVraag()
            {

                inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?",
                extraInfo = "Dit is extra info en is verplicht in te vullen",

                boolVerplicht = true,
                vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

            };
            VasteVraag vasteVraag2 = new VasteVraag()
            {

                inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?",
                extraInfo = "Dit is extra info en is verplicht in te vullen",

                boolVerplicht = true,
                vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

            };

            CentraleVraag centraleVraag = new CentraleVraag()
            {
                inhoud = "Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?",
                extraInfo = "Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                datum = new DateTime(2015, 9, 10, 15, 5, 59),
                aantalWinAntwoorden = 1,


            };

            CentraleVraag centraleVraag2 = new CentraleVraag()
            {
                inhoud = "Wat zou er moeten veranderen aan de hogescholen van vandaag?",
                extraInfo = "Wij zijn op zoek naar ideëen, deel uw idee met ons en maak kans op prijzen!",
                datum = new DateTime(2015, 9, 10, 15, 5, 59),
                aantalWinAntwoorden = 1,


            };
            Thema thema1 = new Thema()
            {
                naam = "Sport",

                modules = new List<Module>()


            };
            Thema thema2 = new Thema()
            {
                naam = "Plezier",

                modules = new List<Module>()


            };
            Beloning beloning1 = new Beloning()
            {
                naam = "Cinema tickets",
                beschrijving = "UGC!",
                modules = new List<Module>()


            };
            Beloning beloning2 = new Beloning()
            {
                naam = "Reis naar Madrid",
                beschrijving = "Madrid vliegticket!",
                modules = new List<Module>()


            };


            DossierModule dossierModule = new DossierModule()
            {

                adminNaam = "Admin",
                naam = "Rivierenhof categorie",
                beginDatum = new DateTime(2014, 03, 10, 15, 5, 59),
                eindDatum = new DateTime(2016, 10, 10, 15, 5, 59),
                verplichteVolledigheidsPercentage = 90.5,
                dossierAntwoorden = new List<DossierAntwoord>(),
                status = true


            };
            AgendaModule agendaModule = new AgendaModule()
            {

                adminNaam = "Admin",
                naam = "Sporthal antwerpen",
                beginDatum = new DateTime(2014, 03, 10, 15, 5, 59),
                eindDatum = new DateTime(2016, 10, 10, 15, 5, 59),
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


                    gebruikersNaam = "Gebruiker1",
                    titel = "Mijn oplossing (dossier)" + i,
                    subtitel = "Een plein met fitness toestellen",
                    inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg, antw nummer: " + i,
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    stemmen= new List<Stem>(),
                    percentageVolledigheid = 95,
                    statusOnline = true,
                    extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?",
                    aantalFlags = 0,
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    afbeeldingPath = "~/uploads/Jellyfish.jpg",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    layoutOption = 1,
                    evenementen=new List<Evenement>()
                    
                };

                AgendaAntwoord agendaAntwoord = new AgendaAntwoord()
                {


                    gebruikersNaam = "Gebruiker2",
                    titel = "Mijn oplossing (agenda)" + i,
                    subtitel = "Heraanleg rivierenhof",
                    inhoud = "Heraanleg rivierenhof!blablablablablablablablablablablablablablablablablabla ! Mvg, antw nummer: " + i,
                    extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                    datum = DateTime.Now,
                    stemmen = new List<Stem>(),
                    aantalFlags = 0,
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    statusOnline=true,
                    evenementen = new List<Evenement>()

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

            vasteVraagAntwoord1.vasteVraag = vasteVraag1;
            vasteVraag1.vasteVraagAntwoorden.Add(vasteVraagAntwoord1);

            //DossierModule
            dossierModule.beloning = beloning1;
            dossierModule.thema = thema1;
            dossierModule.centraleVraag = centraleVraag;
            dossierModule.vasteVraagEen = vasteVraag1;
            dossierModule.organisatie = organisatieLeuven;
            organisatieLeuven.modules.Add(dossierModule);
            context.modules.Add(dossierModule);

            //AgendaModule
            agendaModule.beloning = beloning2;
            agendaModule.thema = thema2;
            agendaModule.organisatie = organisatieLeuven;
            agendaModule.centraleVraag = centraleVraag2;
            organisatieLeuven.modules.Add(dossierModule);

    
            context.modules.Add(agendaModule);

            #endregion
            #region geplande modules
            //geplande modules
            int jaar = 2015;
            int jaar2 = 2016;
            for (int x = 0; x < 10; x++)
            {

                jaar += 1;
                jaar2 += 1;

                CentraleVraag cvA = new CentraleVraag()
                {
                    inhoud = "Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?" + x,
                    extraInfo = "Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum = new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 1,


                };
                VasteVraag vvA = new VasteVraag()
                {


                    inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?" + x,
                    extraInfo = "Dit is extra info en is verplicht in te vullen",

                    boolVerplicht = true,
                    vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

                };

                Thema themaA = new Thema()
                {
                    naam = "Sport" + x,

                    modules = new List<Module>()


                };
                Beloning beloningA = new Beloning()
                {
                    naam = "Reis naar barcelona" + x,
                    beschrijving = "Win een reis naar barcelona!",
                    modules = new List<Module>()


                };

                CentraleVraag cvB = new CentraleVraag()
                {
                    inhoud = "Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?" + x,
                    extraInfo = "Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum = new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 1,


                };
                VasteVraag vvB = new VasteVraag()
                {


                    inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?" + x,
                    extraInfo = "Dit is extra info en is verplicht in te vullen",

                    boolVerplicht = true,
                    vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

                };

                Thema themaB = new Thema()
                {
                    naam = "Sport" + x,

                    modules = new List<Module>()


                };
                Beloning beloningB = new Beloning()
                {
                    naam = "Reis naar barcelona" + x,
                    beschrijving = "Win een reis naar barcelona!",
                    modules = new List<Module>()


                };

                DossierModule geplandeDossierModule = new DossierModule()
                {

                    adminNaam = "Admin",
                    naam = "Rivierenhof speeltuin",
                    beginDatum = new DateTime(jaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(jaar2, 10, 10, 15, 5, 59),
                    verplichteVolledigheidsPercentage = 90.5,

                    dossierAntwoorden = new List<DossierAntwoord>(),
                    status = false


                };
                geplandeDossierModule.beloning = beloningA;
                geplandeDossierModule.centraleVraag = cvA;
                geplandeDossierModule.thema = themaA;
                geplandeDossierModule.organisatie = organisatieLeuven;
                geplandeDossierModule.vasteVraagEen = vvA;
                context.modules.Add(geplandeDossierModule);


                AgendaModule geplandeAgendaModule = new AgendaModule()
                {

                    adminNaam = "Admin",
                    naam = "Hoe creatief ben jij?!",
                    beginDatum = new DateTime(jaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(jaar2, 10, 10, 15, 5, 59),
                    agendaAntwoorden = new List<AgendaAntwoord>(),
                    status = false


                };
                geplandeAgendaModule.centraleVraag = cvB;
                geplandeAgendaModule.beloning = beloningB;
                geplandeAgendaModule.thema = themaB;
                geplandeAgendaModule.organisatie = organisatieLeuven;
                context.modules.Add(geplandeAgendaModule);



            }


            #endregion
            #region gesloten modules
            //gesloten modules
            int oldJaar = 1950;
            int oldJaar2 = 1951;
            for (int x = 0; x < 4; x++)
            {
                CentraleVraag cvX = new CentraleVraag()
                {
                    inhoud = "Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?" + x,
                    extraInfo = "Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum = new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 3,


                };
                VasteVraag vvX = new VasteVraag()
                {


                    inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?" + x,
                    extraInfo = "Dit is extra info en is verplicht in te vullen",

                    boolVerplicht = true,
                    vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

                };

                Thema themaX = new Thema()
                {
                    naam = "Sport" + x,

                    modules = new List<Module>()


                };
                Beloning beloningX = new Beloning()
                {
                    naam = "Reis naar barcelona" + x,
                    beschrijving = "Win een reis naar barcelona!",
                    modules = new List<Module>()


                };

                CentraleVraag cvY = new CentraleVraag()
                {
                    inhoud = "Wat zou er moeten gebeuren in het park Rivierenhof volgens jullie?" + x,
                    extraInfo = "Wij zijn van plan om extra ideeen toe te voegen , deel uw idee met ons en maak kans op prijzen!",
                    datum = new DateTime(2015, 9, 10, 15, 5, 59),
                    aantalWinAntwoorden = 1,


                };
                VasteVraag vvY = new VasteVraag()
                {


                    inhoud = "Wat voor impact heeft dit voor de gebruikers van uw idee?" + x,
                    extraInfo = "Dit is extra info en is verplicht in te vullen",

                    boolVerplicht = true,
                    vasteVraagAntwoorden = new List<VasteVraagAntwoord>()

                };

                Thema themaY = new Thema()
                {
                    naam = "Sport" + x,

                    modules = new List<Module>()


                };
                Beloning beloningY = new Beloning()
                {
                    naam = "Reis naar barcelona" + x,
                    beschrijving = "Win een reis naar barcelona!",
                    modules = new List<Module>()


                };

                oldJaar += 1;
                oldJaar2 += 1;

                DossierModule geslotenDossierModule = new DossierModule()
                {

                    adminNaam = "Admin",
                    naam = "Gesloten dossiermodule" + x,
                    beginDatum = new DateTime(oldJaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(oldJaar2, 10, 10, 15, 5, 59),
                    verplichteVolledigheidsPercentage = 90.5,
                    
                    dossierAntwoorden = new List<DossierAntwoord>(),
                    status = false


                };
                geslotenDossierModule.beloning = beloningX;
                geslotenDossierModule.centraleVraag = cvX;
                geslotenDossierModule.thema = themaX;
                geslotenDossierModule.organisatie = organisatieLeuven;
                geslotenDossierModule.vasteVraagEen = vvX;
                context.modules.Add(geslotenDossierModule);


                AgendaModule geslotenAgendaModule = new AgendaModule()
                {

                    adminNaam = "Admin",
                    naam = "Gesloten agendamodule" + x,
                    beginDatum = new DateTime(oldJaar, 03, 10, 15, 5, 59),
                    eindDatum = new DateTime(oldJaar2, 10, 10, 15, 5, 59),
                    agendaAntwoorden = new List<AgendaAntwoord>(),
                    status = false


                };
                geslotenAgendaModule.centraleVraag = cvY;
                geslotenAgendaModule.beloning = beloningY;
                geslotenAgendaModule.thema = themaY;
                geslotenAgendaModule.organisatie = organisatieLeuven;
                context.modules.Add(geslotenAgendaModule);

                for (int i = 0; i <= 2; i++)
                {

                    Evenement evenementA = new Evenement()
                    {
                        title = "Maggie De Block Ontvangt voorstel",
                        startDatum = new DateTime(2015, 03, 01, 15, 5, 59),
                        eindDatum = new DateTime(2015, 03, 02, 15, 5, 59),
                        locatie = "Leuven",
                        evenementText = "Vandaag heeft Maggie De Block onze voorstel aangenomen. 'Ik hoop zo snel mogelijk werk te kunnen maken van dit voorstel': zei Maggie De Block Vandaag"
                    };

                    Evenement evenementB = new Evenement()
                    {
                        title = "Het voorstel komt in de kamer",
                        startDatum = new DateTime(2015, 04, 01, 15, 5, 59),
                        eindDatum = new DateTime(2015, 04, 05, 15, 5, 59),
                        locatie = "Brussel",
                        evenementText = "Het Voorstel is in de kamer verschenen, er wordt verwacht dat er zo snel mogelijk gestemt wordt"
                    };

                    Evenement evenementC = new Evenement()
                    {
                        title = "Het voorstel is gestemd",
                        startDatum = new DateTime(2015, 04, 10, 15, 5, 59),
                        eindDatum = new DateTime(2015, 04, 11, 15, 5, 59),
                        locatie = "Brussel",
                        evenementText = "Het voorstel is gestemt"
                    };

                    Evenement evenementD = new Evenement()
                    {
                        title = "ActiePlan van 2016",
                        startDatum = new DateTime(2015, 05, 13, 15, 5, 59),
                        eindDatum = new DateTime(2015, 05, 14, 15, 5, 59),
                        locatie = "Brussel",
                        evenementText = "Het voorstel maakt deel uit van het Actieplan van 2016, er wordt verwacht dat deze zo snel mogelijk wordt uitgevoerd"
                    };

                    List<Evenement> evenementenList = new List<Evenement>();
                    evenementenList.Add(evenementA);
                    evenementenList.Add(evenementB);
                    evenementenList.Add(evenementC);
                    evenementenList.Add(evenementD);

                    DossierAntwoord dossierAntwoord = new DossierAntwoord()
                    {


                        gebruikersNaam = "Gebruiker1",
                        titel = "Mijn oplossing (dossier)" + i,
                        subtitel = "Een plein met fitness toestellen",
                        inhoud = "Een plein met fitness toestellen zou heel nuttig zijn voor de sportieve bewoners/bezoekers! Mvg, antw nummer: " + i,
                        extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                        datum = DateTime.Now,
                        stemmen = new List<Stem>(),
                        percentageVolledigheid = 95,
                        statusOnline = true,
                        extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?",
                        aantalFlags = 0,
                        comments = new List<Comment>(),
                        vasteTags = new List<VasteTag>(),
                        persoonlijkeTags = new List<PersoonlijkeTag>(),
                        afbeeldingPath = "~/uploads/Jellyfish.jpg",
                        textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                        textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                        layoutOption = 1,
                        evenementen = evenementenList
                    };

                    AgendaAntwoord agendaAntwoord = new AgendaAntwoord()
                    {


                        gebruikersNaam = "Gebruiker2",
                        titel = "Mijn oplossing (agenda)" + i,
                        subtitel = "Heraanleg rivierenhof",
                        inhoud = "Heraanleg rivierenhof!blablablablablablablablablablablablablablablablablabla ! Mvg, antw nummer: " + i,
                        extraInfo = "Zeer positieve reacties ivm deze idee, besproken met de buurtbewoners van rivierenhof =)",
                        datum = DateTime.Now,
                        stemmen = new List<Stem>(),
                        aantalFlags = 0,
                        vasteTags = new List<VasteTag>(),
                        persoonlijkeTags = new List<PersoonlijkeTag>(),
                        statusOnline=true,
                    };

                    

                    geslotenAgendaModule.agendaAntwoorden.Add(agendaAntwoord);
                    agendaAntwoord.module = geslotenAgendaModule;
                    geslotenDossierModule.dossierAntwoorden.Add(dossierAntwoord);
                    dossierAntwoord.module = geslotenDossierModule;

                }
            }


            #endregion
            
            context.SaveChanges();

        }
        
    }
   
}
