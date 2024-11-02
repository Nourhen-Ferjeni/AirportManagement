using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
   public class AMContext : DbContext
    {
        //DBSET  (les tables crée dans la BD
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        //OnConfiguring  ( Connexion au BD)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=AirportManagementDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }


        //Configurations Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            // ou cette methode sans dossier conf
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            //modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");
            base.OnModelCreating(modelBuilder);
        }
    }
}
