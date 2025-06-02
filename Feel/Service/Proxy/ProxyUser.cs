namespace Feel.Service.Proxy
{
    public class ProxyUser(UserService user)
    {

        public async Task SendRequestAsync(Func<UserService, Task> action)
        {
            await action(user);
        }

        public async Task<T> SendRequestAsync<T>(Func<UserService, Task<T>> action)
        {
            return await action(user);
        }
    }
}

//// ESEMPIO DI UTILIZZO
//private async Task GetRecords()
//{
//    var result = await Proxy.SendRequestAsync(a => a.GetArticoliAsync());
//    Model.Articoli = result;
//}