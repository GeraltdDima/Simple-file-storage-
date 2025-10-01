namespace Models.Factories
{
    public interface ISignalRMessageFactory
    {
        Task SendMessageAsync(MessageDto message);
    }
}