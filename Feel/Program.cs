using Blazored.LocalStorage;
using Feel;
using Feel.Service;
using Feel.Service.ChangeStateHelper;
using Feel.Service.LocalStorage;
using Feel.Service.Proxy;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Localizzazione
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var culture = new CultureInfo("it");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// Localstorage con convertitore per DateOnly (bisogna proprio scriverne uno perchè LocalStorage legge solo string)

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddScoped<LocalDbService>();

// Services

builder.Services.AddScoped<ObiettivoService>();
builder.Services.AddScoped<UserService>();

// Services di ascolto

builder.Services.AddScoped<ObiettiviStateService>();
builder.Services.AddScoped<UserStateService>();

// Proxy
builder.Services.AddScoped<ProxyObiettivi>();
builder.Services.AddScoped<ProxyUser>();

await builder.Build().RunAsync();
