using Microsoft.ApplicationInsights.Extensibility;
using PruebaTecnicaRenting.Infrastructure.Extensions;
using PruebaTecnicaRenting.WebApi.Base.Extensions;
using PruebaTecnicaRenting.WebApi.Base.Filters;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(AppExceptionFilterAttribute));
});

builder.Services.AddApplicationInsightsTelemetry(configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRentingSwagger();
builder.Services.AddRentingCors(configuration);

builder.Services.AddApplication(configuration);
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UsePathBase(configuration.GetValue("PathBase", string.Empty));

app.UseRentingCors();
app.UseRentingHeaders();
app.UseRentingSwagger(configuration);

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
