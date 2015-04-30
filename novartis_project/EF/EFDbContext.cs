using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using JPP.Domain;

namespace JPP.DAL.EF
{


    [DbConfigurationType(typeof(EFDbConfiguration))]
    public class EFDbContext : DbContext
    {


        public EFDbContext()
            : base("DataConnection")
        {

       

       }


        public DbSet<AgendaAntwoord> agendaAntwoorden { get; set; }
        public DbSet<DossierAntwoord> dossierAntwoorden { get; set; }
        public DbSet<Dossiermodule> dossiermodules { get; set; }
        public DbSet<Agendamodule> agendamodules { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Beloning> beloningen { get; set; }
        public DbSet<Evenement> evenementen { get; set; }
        public DbSet<VasteVraag> vasteVragen { get; set; }
        public DbSet<CentraleVraag> centraleVragen { get; set; }
        public DbSet<Thema> themas { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<PersoonlijkeTag> persoonlijkeTags { get; set; }
        public DbSet<Voorstel> voorstellen { get; set; }
        public DbSet<VasteVraagAntwoord> vasteVraagAntwoorden { get; set; }
     



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
