using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_CristopherMarte.Components;
using Parcial1_AP1_CristopherMarte.DAL;
using Parcial1_AP1_CristopherMarte.Models;
using Parcial1_AP1_CristopherMarte.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<Contexto>(c => c.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));
builder.Services.AddScoped<MetaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
