namespace Feel.Service.Proxy
{
    public class ProxyLocalization(LocalizationService service)
    {
        public async Task SendRequestAsync(Func<LocalizationService, Task> action)
            => await action(service);

        public async Task<T> SendRequestAsync<T>(Func<LocalizationService, Task<T>> action)
            => await action(service);
    }
}
