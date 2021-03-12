using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace HousePlantz.Data.Models
{
    public class PlantCatalogContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"Server=(localdb)\mssqllocaldb;Database=PlantCatalog;Integrated Security=True");
        }

    }
}
