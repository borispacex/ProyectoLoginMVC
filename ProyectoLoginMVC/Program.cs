using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProyectoLoginMVC.Models;
using ProyectoLoginMVC.Services.Contrato;
using ProyectoLoginMVC.Services.Implementacion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregamos el Context
builder.Services.AddDbContext<Dbprueba2Context>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
});

// inyectamos el servicio
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Inyectamos la Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Inicio/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();
