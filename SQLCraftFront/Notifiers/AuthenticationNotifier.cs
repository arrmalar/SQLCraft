namespace SQLCraftFront.Notifiers
{
    public class AuthenticationNotifier : IAuthenticationNotifier
    {
        public event Action OnAuthenticationStateChanged;

        public void NotifyAuthenticationStateChanged()
        {
            OnAuthenticationStateChanged?.Invoke();
        }
    }
}
