using LMALP.Models.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace LMALP.Models
{
    public class BddContext : DbContext
    {
        public BddContext() : base()
        {

        }

        public DbSet<Personne> Personnes{ get; set; }
              
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=LMALP");
            }
            else
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Personnes.AddRange(
                new Personne
                {
                    Id = 1,
                    Nom = "Ond",
                    Prenom = "Nelly",
                    Ville = "Paris",
                    Email = "ond@gmail.com",
                    DateDeNaissance = new DateTime(2002, 04, 15),
                    Telephone = "0656544154",
                    Password = Dal.EncodeMD5("aaaa"),
                    Role = Role.Adherent
                },
                new Personne
                {
                    //Id = 1,
                    Nom = "Du Manoir",
                    Prenom = "Gaetan",
                    Ville = "Grenoble",
                    Email = "gaetan@gmail.com",
                    DateDeNaissance = new DateTime(1995, 04, 15),
                    Telephone = "0654441518",
                    Password = Dal.EncodeMD5("bbbb"),
                    Role = Role.Admin
                }
                );
            this.SaveChanges();
        }
    }
}

