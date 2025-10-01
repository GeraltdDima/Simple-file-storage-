using Models.Factories;
using Models;

namespace Services
{
    public class SignalRService : ISignalRService
    {
        private readonly ISignalRMessageFactory _signalRMessageFactory;
        
        public SignalRService(ISignalRMessageFactory signalRMessageFactory)
        {
            _signalRMessageFactory = signalRMessageFactory;
        }
        
        public async Task SendMessageAsync(MessageDto message) =>
            await _signalRMessageFactory.SendMessageAsync(message);
    }
}