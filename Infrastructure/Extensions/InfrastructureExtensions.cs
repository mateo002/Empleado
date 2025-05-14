using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;
using PruebaTecnicaRenting.Infrastructure.EntityFramework;
using PruebaTecnicaRenting.Infrastructure.EntityFramework.Repositories;

namespace PruebaTecnicaRenting.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddSqlServer(services, configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Empleado>, Repository<Empleado>>();
            services.AddScoped<IRepository<Person>, Repository<Person>>();
            return services;
        }

        private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistenceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Base"),
                    sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.MigrationsHistoryTable("__MicroMigrationHistory", configuration.GetConnectionString("BaseSchema"));
                    });

                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });
        }
    }
}
