﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using JPP.BL.Domain;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;


namespace JPP.DAL.EF
{


    [DbConfigurationType(typeof(EFDbConfiguration))]
    public class EFDbContext : DbContext
    {


        public EFDbContext()
            : base("dbteamnovartis")
        {

       

       }

        //Antwoorden
      
        public DbSet<Antwoord> antwoord { get; set; }
        public DbSet<Flag> flags { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Stem> stemmen { get; set; }
        public DbSet<Evenement> evenementen { get; set; }
        
        public DbSet<VasteTag> tags { get; set; }
        public DbSet<VasteVraagAntwoord> vasteVraagAntwoorden { get; set; }

        //Modules
        public DbSet<Organisatie> organisaties { get; set; }
        public DbSet<Module> modules { get; set; }

        public DbSet<Beloning> beloningen { get; set; }
        public DbSet<Thema> themas { get; set; }
        //Vragen

        public DbSet<VasteVraag> vasteVragen { get; set; }
        public DbSet<CentraleVraag> centraleVragen { get; set; }


      
        
        
       
     



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove pluralizing tablenames, • Geen meervouden voor tabelnamen
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //// 'Bericht.Id' as unique identifier
            //modelBuilder.Entity<Bericht>().HasKey(b => b.id);

            //// 'Recensie.Id' as unique identifier
            //modelBuilder.Entity<Recensie>().HasKey(r => r.id);

            //// 'Contactpersoon.Id' as unique identifier
            //modelBuilder.Entity<Contactpersoon>().HasKey(c => c.id);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           
        }
    }
}
