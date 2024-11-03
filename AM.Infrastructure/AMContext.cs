using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //Owned Type
            // modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);

            // ou cette methode sans dossier conf
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            //modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");

            //Table Par Hierarchy (TPH) config


            //modelBuilder.Entity<Passenger>()
            //            .HasDiscriminator<int>("IsTraveller")
            //            .HasValue<Passenger>(0)
            //            .HasValue<Traveller>(1)
            //            .HasValue<Staff>(2);

            //Table Par Type (TPT) config
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //Configure la clé primaire de la porteuse de données
            modelBuilder.Entity<Ticket>().HasKey(t => new { t.FlightFK, t.PassengerFK });
            
            base.OnModelCreating(modelBuilder);
        }

        //pré-conventions
        // tous datetime (date au lieu de datetime2
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("DateTime");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
