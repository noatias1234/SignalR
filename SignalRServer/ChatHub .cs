using Microsoft.AspNetCore.SignalR;

namespace SignalRServer
{
    public class ChatHub : Hub // Hub class manages connections, groups, and messaging
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}