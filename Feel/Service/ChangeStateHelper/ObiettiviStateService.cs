namespace Feel.Service.ChangeStateHelper
{
    public class ObiettiviStateService
    {
        public event Func<Task>? ObiettiviAggiornati;

        public async Task NotificaAggiornamentoAsync()
        {
            if (ObiettiviAggiornati is null) return;

            var handlers = ObiettiviAggiornati.GetInvocationList().Cast<Func<Task>>();
            foreach (var handler in handlers)
            {
                await handler.Invoke();
            }
        }
    }


}
