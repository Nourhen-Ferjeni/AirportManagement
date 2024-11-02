using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        { 
            // Configurer FullName comme un type détenu
            builder.OwnsOne(p => p.FullName, fullName =>
            {
                // Configuration de FirstName dans FullName

                fullName.Property(fn => fn.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("PassFirstName");

                // Configuration de LastName dans FullName
                fullName.Property(fn => fn.LastName)
                    .IsRequired()
                    .HasColumnName("PassLastName");
            });
        }
    }
}
