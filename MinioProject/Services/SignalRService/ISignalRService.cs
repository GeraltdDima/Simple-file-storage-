using Models;

namespace Services
{
    public interface ISignalRService
    {
        Task SendMessageAsync(MessageDto message);
    }
}