using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;


namespace Nomenclatures
{
    public class NomenclaturesContext : DbContext
    {
        public DbSet<Produit> Produits {get; set;}
        public DbSet<MatierePremiere> MatierePremieres {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=Nomenclatures;Trusted_Connection=True"
                );
        }
        
    }

}