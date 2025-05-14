using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaRenting.Domain.Entities;

namespace PruebaTecnicaRenting.Infrastructure.EntityFramework.Configurations
{
    public class CiudadEntityConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("TblCiudad");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ciudadId")
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasColumnName("description");
        }
    }
}
