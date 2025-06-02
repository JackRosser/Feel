using Blazored.LocalStorage;
using System.Reflection;

namespace Feel.Service.LocalStorage
{
    public class LocalDbService(ILocalStorageService storage)
    {

        // Metodi interni di servizio

        private async Task SetAsync<T>(string key, List<T> data)
        {
            await storage.SetItemAsync(key, data);
        }

        private PropertyInfo? GetIdProperty<T>()
        {
            return typeof(T).GetProperty("Id");
        }

        // Crud

        public async Task<IEnumerable<T>> GetAsync<T>(string key, Func<List<T>> defaultFactory)
        {
            var data = await storage.GetItemAsync<List<T>>(key);
            if (data is not null)
                return data;

            var initial = defaultFactory();
            await storage.SetItemAsync(key, initial);
            return initial;
        }

        public async Task<T?> GetFirstAsync<T>(string key, Func<List<T>> defaultFactory)
        {
            var data = await storage.GetItemAsync<List<T>>(key);

            if (data is { Count: > 0 })
                return data.First();

            var initial = defaultFactory();
            if (initial is { Count: > 0 })
            {
                await storage.SetItemAsync(key, initial);
                return initial.First();
            }

            return default;
        }

        public async Task<T?> GetByIdAsync<T>(string key, Func<List<T>> defaultFactory, int id)
        {
            var list = await GetAsync(key, defaultFactory);
            var idProp = GetIdProperty<T>();


            return list.FirstOrDefault(item =>
                idProp is not null &&
                idProp.PropertyType == typeof(int) &&
                (int?)idProp.GetValue(item) == id);
        }


        public async Task CreateAsync<T>(string key, Func<List<T>> defaultFactory, T newItem)
        {
            var list = (await GetAsync(key, defaultFactory)).ToList();

            // Gestione ID progressivo
            var idProp = GetIdProperty<T>();

            if (idProp is not null && idProp.PropertyType == typeof(int) && idProp.CanWrite)
            {
                var nextId = list.Any()
                    ? list.Max(x => (int?)idProp.GetValue(x) ?? -1) + 1
                    : 0;

                idProp.SetValue(newItem, nextId);
            }

            list.Add(newItem);
            await SetAsync(key, list);
        }

        public async Task UpdateAsync<T>(string key, Func<List<T>> defaultFactory, T updatedItem)
        {
            var list = (await GetAsync(key, defaultFactory)).ToList();
            var idProp = GetIdProperty<T>();


            if (idProp is null || idProp.PropertyType != typeof(int)) return;

            var idValue = (int?)idProp.GetValue(updatedItem);
            if (idValue is null) return;

            var index = list.FindIndex(x =>
                (int?)idProp.GetValue(x) == idValue);

            if (index >= 0)
            {
                list[index] = updatedItem;
                await SetAsync(key, list);
            }
        }

        public async Task DeleteAsync<T>(string key, Func<List<T>> defaultFactory, int id)
        {
            var list = (await GetAsync(key, defaultFactory)).ToList();
            var idProp = GetIdProperty<T>();


            list.RemoveAll(x =>
                idProp is not null &&
                idProp.PropertyType == typeof(int) &&
                (int?)idProp.GetValue(x) == id);

            await SetAsync(key, list);
        }

        public async Task DeleteFirstAsync<T>(string key, Func<List<T>> defaultFactory)
        {
            var list = (await GetAsync(key, defaultFactory)).ToList();

            if (list.Count > 0)
            {
                list.RemoveAt(0);
                await SetAsync(key, list);
            }
        }


        public async Task ClearAllAsync()
        {
            await storage.ClearAsync();
        }

    }
}
