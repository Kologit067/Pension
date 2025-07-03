using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Pension.Data.Contracts;
using Pension.Data.Contracts.Interfactes;
using Pension.Data.Implementation;
using Pension.Service.Contracts.Interfaces;
using Pension.Service.Implementations;
using PensionBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IAverageSalaryRepository, AverageSalaryRepository>();
builder.Services.AddScoped<IPersonSalaryRepository, PersonSalaryRepository>();
builder.Services.AddScoped<IAverageSalaryService, AverageSalaryService>();
builder.Services.AddScoped<IPersonSalaryService, PersonSalaryService>();


ConfigurationManager configurationManager = builder.Configuration;
IConfigurationSection connectionStringsSection = configurationManager.GetSection("ConnectionStrings");
builder.Services.Configure<ConnectionStrings>(connectionStringsSection);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Home}/{action=Index}/{id?}");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PensionBlazor.Client._Imports).Assembly);

app.Run();
