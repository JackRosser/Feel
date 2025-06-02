namespace Feel.Service.ChangeStateHelper
{
    public class UserStateService
    {
        public event Func<Task>? UserAggiornato;

        public async Task NotificaAggiornamentoAsync()
        {
            if (UserAggiornato is null) return;

            var handlers = UserAggiornato.GetInvocationList().Cast<Func<Task>>();
            foreach (var handler in handlers)
            {
                await handler.Invoke();
            }
        }
    }


}
