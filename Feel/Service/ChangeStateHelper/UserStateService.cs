namespace Feel.Service.ChangeStateHelper
{
    public class UserStateService
    {
        public event Func<Task>? UserAggiornato;
        public event Func<Task>? TemaUtenteAggiornato;

        public async Task NotificaAggiornamentoAsync()
        {
            if (UserAggiornato is null) return;

            var handlers = UserAggiornato.GetInvocationList().Cast<Func<Task>>();
            foreach (var handler in handlers)
            {
                await handler.Invoke();
            }
        }

        public async Task NotificaCambioTemaAsync()
        {
            if (TemaUtenteAggiornato is not null)
            {
                var handlers = TemaUtenteAggiornato.GetInvocationList().Cast<Func<Task>>();
                foreach (var handler in handlers)
                    await handler.Invoke();
            }
        }
    }


}
