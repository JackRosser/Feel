using TG.Blazor.IndexedDB;
namespace Feel.Service
{
    public class IndexedDbService<T>(IndexedDBManager db) : IIndexedDbService<T>
    {

        public async Task<List<T>> GetAllAsync(string storeName)
        {
            return await db.GetRecords<T>(storeName);
        }

        public async Task<T?> GetByIdAsync(string storeName, int id)
        {
            return await db.GetRecordById<int, T>(storeName, id);
        }


        public async Task PostAsync(string storeName, T item)
        {
            var record = new StoreRecord<T>
            {
                Storename = storeName,
                Data = item
            };

            await db.AddRecord(record);
        }


        public async Task UpdateAsync(string storeName, T item)
        {
            var record = new StoreRecord<T>
            {
                Storename = storeName,
                Data = item
            };

            await db.UpdateRecord(record);
        }


        public async Task DeleteAsync(string storeName, object key)
        {
            await db.DeleteRecord(storeName, key);
        }
    }

}

// Esempi di utilizzo

// Faccio la classe

//public class Alunno
//{
//    public int Id { get; set; } // generato automaticamente se StoreSchema ha Auto = true
//    public string Name { get; set; } = string.Empty;

//    // Serializzazione manuale di DateOnly come stringa
//    public string DataNascita { get; set; } = string.Empty;

//    // Proprietà di supporto non salvata, per semplificarti la vita
//    [NotMapped]
//    public DateOnly DataNascitaParsed
//    {
//        get => DateOnly.Parse(DataNascita);
//        set => DataNascita = value.ToString("yyyy-MM-dd");
//    }
//}

// Aggiungo al db

//dbStore.Stores.Add(new StoreSchema
//{
//    Name = "alunni",
//    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
//    Indexes = new List<IndexSpec>
//    {
//        new() { Name = "name", KeyPath = "name", Auto = false },
//        new() { Name = "datanascita", KeyPath = "datanascita", Auto = false }
//    }
//});

// Creo il service

//@inject IIndexedDbService<Alunno> AlunnoService


//// Add

//    var nuovoAlunno = new Alunno
//    {
//        Name = "Mario Rossi",
//        DataNascitaParsed = new DateOnly(2010, 5, 30) // setter converte in stringa
//    };

//await AlunnoService.PostAsync("alunni", nuovoAlunno);

//// Edit

//var alunni = await AlunnoService.GetAllAsync("alunni");
//var alunno = alunni.FirstOrDefault(a => a.Name == "Mario Rossi");

//if (alunno is not null)
//{
//    alunno.Name = "Mario R.";
//    await AlunnoService.UpdateAsync("alunni", alunno);
//}

//// GetAll

//var alunni = await AlunnoService.GetAllAsync("alunni");

//foreach (var a in alunni)
//{
//    DateOnly data = a.DataNascitaParsed; // getter estrae il DateOnly
//    Console.WriteLine($"{a.Name} nato il {data:dd/MM/yyyy}");
//}

//// Get by id
//int id = 1;
//var alunno = await AlunnoService.GetByIdAsync("alunni", id);

//// delete

//var alunni = await AlunnoService.GetAllAsync("alunni");
//var alunno = alunni.FirstOrDefault(a => a.Name == "Mario R.");

//if (alunno is not null)
//{
//    await AlunnoService.DeleteAsync("alunni", alunno.Id);
//}


////////////////////////CREAZIONE SERVICE
///
//public interface IAlunnoService
//{
//    Task<List<Alunno>> GetAllAsync();
//    Task<Alunno?> GetByIdAsync(int id);
//    Task PostAsync(Alunno item);
//    Task UpdateAsync(Alunno item);
//    Task DeleteAsync(int id);
//}

//using TG.Blazor.IndexedDB;
//using Feel.Shared.Models; // o dove hai definito Alunno

//namespace Feel.Service
//{
//    public class AlunnoService(IIndexedDbService<Alunno> innerService) : IAlunnoService
//    {
//        private const string Store = "alunni";

//        public Task<List<Alunno>> GetAllAsync() => innerService.GetAllAsync(Store);
//        public Task<Alunno?> GetByIdAsync(int id) => innerService.GetByIdAsync(Store, id);
//        public Task PostAsync(Alunno item) => innerService.PostAsync(Store, item);
//        public Task UpdateAsync(Alunno item) => innerService.UpdateAsync(Store, item);
//        public Task DeleteAsync(int id) => innerService.DeleteAsync(Store, id);
//    }
//}


//builder.Services.AddScoped<IAlunnoService, AlunnoService>();

//builder.Services.AddIndexedDB(dbStore =>
//{
//    dbStore.DbName = "FeelDb";
//    dbStore.Version = 1;
//    dbStore.Stores.Add(new StoreSchema
//    {
//        Name = "alunni", // ⬅️ ECCO COSA DEVE CORRISPONDERE PRIVATE CONST STRING
//        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
//        Indexes = new List<IndexSpec>
//        {
//            new() { Name = "name", KeyPath = "name", Auto = false },
//            new() { Name = "datanascita", KeyPath = "datanascita", Auto = false }
//        }
//    });
//});
