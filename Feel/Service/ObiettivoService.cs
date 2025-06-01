using Feel.Service.LocalStorage;
using Feel.Shared.Dto.Obiettivi;

namespace Feel.Service
{
    public class ObiettivoService(LocalDbService service)
    {
        private const string Key = "obiettivi";
        private static List<ObiettivoDto> DefaultFactory() => new();

        public Task<IEnumerable<ObiettivoDto>> GetAllObiettiviAsync() =>
            service.GetAsync<ObiettivoDto>(Key, DefaultFactory);

        public Task<ObiettivoDto?> GetObiettivoAsync(int id) =>
            service.GetByIdAsync<ObiettivoDto>(Key, DefaultFactory, id);

        public Task CreateNewObiettivoAsync(CreateObiettivoDto obiettivo)
        {
            var dto = new ObiettivoDto
            {
                Categoria = obiettivo.Categoria,
                Titolo = obiettivo.Titolo,
                Descrizione = obiettivo.Descrizione,
                DataCreazione = obiettivo.DataCreazione,
                Scadenza = obiettivo.Scadenza,
                Completed = obiettivo.Completed,
                Target = obiettivo.Target,
                CheckMark = obiettivo.CheckMark
            };

            return service.CreateAsync<ObiettivoDto>(Key, DefaultFactory, dto);
        }

        public Task UpdateObiettivoAsync(UpdateObiettivoDto obiettivo)
        {
            var dto = new ObiettivoDto
            {
                Id = obiettivo.Id,
                Categoria = obiettivo.Categoria,
                Titolo = obiettivo.Titolo,
                Descrizione = obiettivo.Descrizione,
                DataCreazione = obiettivo.DataCreazione,
                Scadenza = obiettivo.Scadenza,
                Completed = obiettivo.Completed,
                Target = obiettivo.Target,
                CheckMark = obiettivo.CheckMark
            };

            return service.UpdateAsync<ObiettivoDto>(Key, DefaultFactory, dto);
        }

        public Task DeleteObiettivoAsync(int id) =>
            service.DeleteAsync<ObiettivoDto>(Key, DefaultFactory, id);
    }

}
