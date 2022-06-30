using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    internal class SignalRClientChat
    {
        private readonly HubConnection _connection;

        public event Action<string>? MessageReceiveEven; // Event - notify to our app when we receive msg
        public SignalRClientChat(HubConnection connection)
        {
            _connection = connection;

            // All who subscribed to this event can receive the msg
            _connection.On<string>("ReceiveMessage", msg => 
                MessageReceiveEven?.Invoke(msg));
        }

        private async Task Connect() // start the connection to our signalR server
        {
            await _connection.StartAsync();
        }

        public async Task SendMessage(string message) // send data to our Hub connection
        {
            await _connection.SendAsync("SendMessage", message); // the string is the method name in Server
        }
    }
}