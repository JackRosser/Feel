using Feel.Shared.Dto.Obiettivi;
using Feel.Shared.Enum;
using Microsoft.AspNetCore.Components;

namespace Feel.Components.Obiettivo
{
    public partial class Filtro : MainClassBase
    {
        [Parameter] public IEnumerable<ObiettivoDto> ListaObiettivi { get; set; } = [];
        [Parameter] public EventCallback<IEnumerable<ObiettivoDto>> OnListaFiltrata { get; set; }

        private bool? CompletedFilter { get; set; }
        private Category? CategoriaFilter { get; set; }

        private void AggiornaLista()
        {
            var filtrata = ListaObiettivi
                .Where(o => !CompletedFilter.HasValue || o.Completed == CompletedFilter.Value)
                .Where(o => !CategoriaFilter.HasValue || o.Categoria == CategoriaFilter.Value);

            OnListaFiltrata.InvokeAsync(filtrata);
        }

        private void OnCompletedChanged(ChangeEventArgs e)
        {
            var value = e.Value?.ToString();
            CompletedFilter = string.IsNullOrWhiteSpace(value) ? null : value == "true";
            AggiornaLista();
        }

        private void OnCategoriaChanged(ChangeEventArgs e)
        {
            var value = e.Value?.ToString();
            CategoriaFilter = string.IsNullOrWhiteSpace(value) ? null : Enum.Parse<Category>(value);
            AggiornaLista();
        }

        private void ClearCompletedFilter()
        {
            CompletedFilter = null;
            AggiornaLista();
        }

        private void ClearCategoriaFilter()
        {
            CategoriaFilter = null;
            AggiornaLista();
        }

        private void ResetFilters()
        {
            CompletedFilter = null;
            CategoriaFilter = null;
            AggiornaLista();
        }
    }
}
