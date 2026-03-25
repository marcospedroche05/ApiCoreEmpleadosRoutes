using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlEmpleados");
builder.Services.AddDbContext<EmpleadoContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RepositoryEmpleados>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "Mi API de Producción";
    // Opcional: configurar temas u otras opciones
});

app.MapGet("/", () => Results.Redirect("/scalar/v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
