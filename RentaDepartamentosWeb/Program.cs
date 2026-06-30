using Microsoft.Data.SqlClient;
using RentaDepartamentosWeb.Data;
using RentaDepartamentosWeb.Repositories;
using RentaDepartamentosWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Registrar ConexionBD para las conexiones a la base de datos
builder.Services.AddSingleton<ConexionBD>();

// Registrar repositorios
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

// Registrar servicios de negocio
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días. Es posible que desee cambiar esto para escenarios de producción, consulte https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Ejecutar la aplicación
app.Run();
