using Microsoft.AspNetCore.SignalR;

namespace Models.Factories
{
    public class SignalRMessageFactory : ISignalRMessageFactory
    {
        private readonly IHubContext<ChatHub> _hubContext;
        
        public SignalRMessageFactory(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        public async Task SendMessageAsync(MessageDto message) =>
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
}