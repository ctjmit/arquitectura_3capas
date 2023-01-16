using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.BL;
using ProyectoCrud.BL.Interface;
using ProyectoCrud.DAL;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;
using ProyectoCrud.DAL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbpruebaContext>(opcion => 
    opcion.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DbpruebaContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IGenericDA, UsuarioDA>();
builder.Services.AddScoped<IUsuarioBL, UsuarioBL>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

builder.Services.AddTransient(typeof(IAuth), typeof(AuthDA));
builder.Services.AddScoped<IUserBL, UserBL>();

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
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
