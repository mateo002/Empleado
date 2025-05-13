using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaRenting.Infrastructure.EntityFramework.Configurations;

namespace PruebaTecnicaRenting.Infrastructure.EntityFramework
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.HasDefaultSchema(_configuration.GetConnectionString("BaseSchema"));
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
