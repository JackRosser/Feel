using Blazored.LocalStorage;
using Feel;
using Feel.Service;
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

// Proxy
builder.Services.AddScoped<ProxyObiettivi>();

await builder.Build().RunAsync();
