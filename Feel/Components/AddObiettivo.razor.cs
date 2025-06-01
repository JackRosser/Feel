namespace Feel.Components
{
    public partial class AddObiettivo : MainClassBase
    {

        public void StartForm()
        {
            if (EditModel.CreateObiettivoForm is null)
            {
                EditModel.CreateObiettivoForm = new();
                EditModel.CreateObiettivoForm.DataCreazione = DateOnly.FromDateTime(DateTime.Now);
            }
            InvokeAsync(StateHasChanged);
        }
        private async Task Save()
        {
            if (EditModel.CreateObiettivoForm is null) return;

            await proxyObiettivi.SendRequestAsync(a => a.CreateNewObiettivoAsync(EditModel.CreateObiettivoForm));
            await GetAllObiettivi();
        }

    }
}
