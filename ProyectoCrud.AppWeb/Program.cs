using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoCrud.BL;
using ProyectoCrud.BL.Interface;
using ProyectoCrud.DAL;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DbpruebaContext>(opcion => 
    opcion.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddScoped<IGenericDA, UsuarioDA>();
builder.Services.AddScoped<IUsuarioBL, UsuarioBL>();



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
