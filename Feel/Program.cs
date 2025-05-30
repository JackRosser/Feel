using Feel;
using Feel.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using TG.Blazor.IndexedDB;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Localizzazione
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var culture = new CultureInfo("it");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

//IndexeDB

builder.Services.AddScoped(typeof(IIndexedDbService<>), typeof(IndexedDbService<>));

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "FeelDb";
    dbStore.Version = 1;
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "obiettivi",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new() { Name = "categoria", KeyPath = "categoria", Auto = false },
            new() { Name = "titolo", KeyPath = "titolo", Auto = false },
            new() { Name = "descrizione", KeyPath = "descrizione", Auto = false },
            new() { Name = "scadenza", KeyPath = "scadenza", Auto = false }
        }
    });
});


await builder.Build().RunAsync();
