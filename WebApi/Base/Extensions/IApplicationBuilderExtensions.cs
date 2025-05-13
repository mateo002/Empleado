using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace PruebaTecnicaRenting.WebApi.Base.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRentingCors(this IApplicationBuilder application)
        {
            return application.UseCors("AllowAll");
        }

        public static IApplicationBuilder UseRentingHeaders(this IApplicationBuilder application)
        {
            application.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "master-only");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
                context.Response.Headers.Add("Pragma", "no-cache");
                context.Response.Headers.Remove("X-Powered-By");
                context.Response.Headers.Remove("Server");
                await next();
            });

            return application;
        }

        public static IApplicationBuilder UseRentingSwagger(this IApplicationBuilder application, IConfiguration configuration)
        {
            var swaggerRoutePrefix = string.IsNullOrWhiteSpace(configuration["PathBase"])
                ? "swagger"
                : $"{configuration["PathBase"]!.TrimStart('/')}-swagger";

            application.UseSwagger(c =>
            {
                c.RouteTemplate = $"{swaggerRoutePrefix}/{{documentName}}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}{configuration["PathBase"]}" } };
                });
            });

            application.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint($"/{swaggerRoutePrefix}/v1/swagger.json", "PruebaTecnicaRenting.WebApi.V1");
                setupAction.RoutePrefix = $"{swaggerRoutePrefix}";
            });

            return application;
        }
    }
}
