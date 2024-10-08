namespace SQLCraftFront.Notifiers
{
    public interface IAuthenticationNotifier
    {
        event Action OnAuthenticationStateChanged;
        void NotifyAuthenticationStateChanged();
    }
}
