namespace Feel.Service.Proxy
{
    public class ProxyObiettivi(ObiettivoService obiettivi)
    {

        public async Task SendRequestAsync(Func<ObiettivoService, Task> action)
        {
            await action(obiettivi);
        }

        public async Task<T> SendRequestAsync<T>(Func<ObiettivoService, Task<T>> action)
        {
            return await action(obiettivi);
        }
    }
}

//// ESEMPIO DI UTILIZZO
//private async Task GetRecords()
//{
//    var result = await Proxy.SendRequestAsync(a => a.GetArticoliAsync());
//    Model.Articoli = result;
//}