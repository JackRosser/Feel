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
        private bool FilterToggle { get; set; } = false;

        private List<Category> CategorieSelezionate { get; set; } = [];

        private string? categoriaTemp
        {
            get => null;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var cat = Enum.Parse<Category>(value);
                    if (!CategorieSelezionate.Contains(cat))
                        CategorieSelezionate.Add(cat);
                    AggiornaLista();
                }
            }
        }

        private void ShowFilters()
        {
            FilterToggle = !FilterToggle;
        }

        private void AggiornaLista()
        {
            var filtrata = ListaObiettivi
                .Where(o => !CompletedFilter.HasValue || o.Completed == CompletedFilter.Value)
                .Where(o => CategorieSelezionate.Count == 0 || (o.Categoria.HasValue && CategorieSelezionate.Contains(o.Categoria.Value)));

            OnListaFiltrata.InvokeAsync(filtrata);
        }

        private void OnCompletedChanged(ChangeEventArgs e)
        {
            var value = e.Value?.ToString();
            CompletedFilter = string.IsNullOrWhiteSpace(value) ? null : value == "true";
            AggiornaLista();
        }

        private void ClearCompletedFilter()
        {
            CompletedFilter = null;
            AggiornaLista();
        }

        private void ClearCategoria(Category cat)
        {
            CategorieSelezionate.Remove(cat);
            AggiornaLista();
        }

        private void ResetFilters()
        {
            CompletedFilter = null;
            CategorieSelezionate.Clear();
            AggiornaLista();
        }
    }
}
