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

___________________________________________________________________________________

Cascading Value
Se ho un solo tipo di oggetto posso omettere il nome nel componente figlio, basta che passo tipo
e scelgo un nome in importazione, altrimenti

PADRE
<CascadingValue Name="CurrentObiettivo" Value="@obiettivo">
    <OffCanvas />
</CascadingValue>

FIGLIO
@code {
    [CascadingParameter(Name = "CurrentObiettivo")]
    public Obiettivo? Obiettivo { get; set; }
}

____________________________________________________________________________________

IndexeDB

Dopo aver installato il pacchetto TG.Blazor.IndexedDB

Link https://www.nuget.org/packages/TG.Blazor.IndexedDB

 <!--IndexedDB importante metterlo DOPO blazor.webassembly.js-->
    <script src="_content/TG.Blazor.IndexedDB/indexedDb.Blazor.js"></script>

Assicurarsi che la versione nel proj sia <PackageReference Include="TG.Blazor.IndexedDB" Version="1.5.0-preview" />

_____________________________________________________________________________________

Esempio Markup String

Info="@((MarkupString)Localizer[ResourceLanguage.AvvicinatiTarget].Value)"