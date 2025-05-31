namespace Feel.Components
{
    public partial class AddObiettivo : MainClassBase
    {
        public void StartForm()
        {
            EditModel.CreateObiettivoForm = new();
            InvokeAsync(StateHasChanged);
        }
        private async Task Save()
        {
            await Task.Delay(1000);
            Console.WriteLine("Obiettivo salvato con successo!");
        }
    }
}
