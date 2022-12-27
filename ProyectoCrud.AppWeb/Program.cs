using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoCrud.BL.Services;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Models;
using ProyectoCrud.DAL.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbcrudcoreContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

// primera innyeccion de dependencias
//todo controlador que use esta interfaz <IRepositorioGeneric<Usuario> estara trabajando directamente con la clase ContactoRepositories
builder.Services.AddScoped<IRepositorioGeneric<Usuario>, ContactoRepositories>();

//segunda inyeccion de dependencia
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
