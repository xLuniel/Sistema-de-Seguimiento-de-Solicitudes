using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sistema_de_Seguimiento_de_Solicitudes;

using Sistema_de_Seguimiento_de_Solicitudes.Services;
using Sistema_de_Seguimiento_de_Solicitudes.Services.LoginServices;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configuracion de HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7123/") });

builder.Services.AddScoped<ICalendarioService, CalendarioService>();

// Registrando los servicios
builder.Services.AddScoped<IExpedienteService, ExpedienteService>();
builder.Services.AddScoped<AuthService>();

// Register CustomAuthenticationStateProvider
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddAuthorizationCore(); // Para Blazor WASM
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// Add authorization services
builder.Services.AddAuthorizationCore();


builder.Services.AddSweetAlert2();

builder.Services.AddRadzenComponents();


await builder.Build().RunAsync();
