using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient.SignalRConnection;

public class StartConnection
{
    HubConnection _connection;

    public HubConnection Start()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5094/chatHub")
            .WithAutomaticReconnect()
            .Build();

        _connection.StartAsync();

        // When connection is closed (disconnected) wait delay before start
        _connection.Closed += async (_) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        };
        return _connection;
    }
}