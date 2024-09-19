using Microsoft.EntityFrameworkCore;
using Prularia.Models;
using Prularia.Repositories;
using Prularia.Services;
using PrulariaModels.Repositories.Interfaces;
using PrulariaModels.Repositories.SQLRepos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrulariaContext>(
    options => options.UseMySQL(
        builder.Configuration.GetConnectionString("prularia")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<BestellingService>();
builder.Services.AddTransient<KlantService>();
builder.Services.AddTransient<SecurityService>();

builder.Services.AddTransient<IBestellingRepo, SQLBestellingRepo>();
builder.Services.AddTransient<IKlantRepo, SQLKlantRepo>();
builder.Services.AddTransient<ISecurityRepo, SQLSecurityRepo>();

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
