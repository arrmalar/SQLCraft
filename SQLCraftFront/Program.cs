using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;
using SQLCraftFront.Components;
using SQLCraftFront.Handlers;
using SQLCraftFront.Handlers.IHandlers;
using SQLCraftFront.Notifiers;
using SQLCraftFront.Providers;
using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("AuthenticatedHttpClient").AddHttpMessageHandler<AddHeadersDelegatingHandler>();
builder.Services.AddTransient<AddHeadersDelegatingHandler>();

builder.Services.AddSingleton<IAuthenticationNotifier, AuthenticationNotifier>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<ITokenManagerService, TokenManagerService>();
builder.Services.AddScoped<IClaimsManagerService, ClaimsManagerService>();
builder.Services.AddScoped<IRepositoryProvider, RepositoryProvider>();
builder.Services.AddScoped<IServicesProvider, ServicesProvider>();

builder.Services.AddScoped<CircuitServicesAccessor>();
builder.Services.AddScoped<CircuitHandler, ServicesAccessorCircuitHandler>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
