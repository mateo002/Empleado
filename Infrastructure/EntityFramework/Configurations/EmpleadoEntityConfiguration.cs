using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaRenting.Domain.Entities;

namespace PruebaTecnicaRenting.Infrastructure.EntityFramework.Configurations
{
    public class EmpleadoEntityConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("TblEmpleado");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("empleadoId")
                .IsRequired();

            builder.Property(x => x.EmpleadoName)
                .HasColumnName("empleadoName");

            builder.Property(x => x.Documento)
                .HasColumnName("documento");

            builder.Property(x => x.CiudadId)
                .HasColumnName("ciudadId");

            builder.Property(x => x.DepartamentoId)
                .HasColumnName("DepartamentoId");
        }
    }
}
