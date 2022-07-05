using Microsoft.AspNetCore.SignalR;

namespace SignalRServer;

public class ChatHub : Hub // Hub class manages connections, groups, and messaging
{
    public async Task SendMessage(string user,string message) // Called by connected client to send message to all clients
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message); // "ReceiveMessage" is the msg type that all connected clients will receive
    }
}