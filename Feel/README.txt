Installare la Localization

1) Nuget Microsoft.Extensions.Localization
2) Nuget Microsoft.Extensions.Localization.Abstractions
3) Incollare Resources e cancellare il precompilato
4) Incollare su "PublicResXFileCodeGenerator" (senza gli apici) su CustomTools in options
5) Ricompilare
6) Aggiungere al Program.cs 

// Localizzazione
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var culture = new CultureInfo("it");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

7) Aggiungere dentro a <PropertyGroup> in .csproj

<BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>