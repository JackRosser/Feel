using Feel.Service.LocalStorage;
using Feel.Shared.Dto.Obiettivi;

namespace Feel.Service
{
    public class ObiettivoService(LocalDbService service)
    {
        private const string Key = "obiettivi";
        private static List<ObiettivoDto> DefaultFactory() => new();

        public async Task<IEnumerable<ObiettivoDto>> GetAllObiettiviAsync()
        {
            return await service.GetAsync<ObiettivoDto>(Key, DefaultFactory);
        }

        public async Task<ObiettivoDto?> GetObiettivoAsync(int id)
        {
            return await service.GetByIdAsync<ObiettivoDto>(Key, DefaultFactory, id);
        }

        public async Task CreateNewObiettivoAsync(CreateObiettivoDto obiettivo)
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
                CheckMark = obiettivo.CheckMark,
                Progressivo = 0
            };

            await service.CreateAsync<ObiettivoDto>(Key, DefaultFactory, dto);
        }

        public async Task UpdateObiettivoAsync(ObiettivoDto obiettivo)
        {

            await service.UpdateAsync<ObiettivoDto>(Key, DefaultFactory, obiettivo);
        }

        public async Task DeleteObiettivoAsync(int id)
        {
            await service.DeleteAsync<ObiettivoDto>(Key, DefaultFactory, id);
        }
    }
}
