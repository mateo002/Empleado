using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaRenting.Domain.Entities;

namespace PruebaTecnicaRenting.Infrastructure.EntityFramework.Configurations
{
    public class DepartamentoEntityConfigurarion : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("TblDepartamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("departamentoId")
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasColumnName("description");
        }
    }
}
