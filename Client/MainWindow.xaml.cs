using System;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRClient.SignalRConnection;

namespace SignalRClient;

public partial class MainWindow : Window
{
    private readonly HubConnection _connection;

    public MainWindow()
    {
        var startConnection = new StartConnection();
        _connection = startConnection.Start();

        _connection.On<string,string>("ReceiveMessage", (user,message) =>
        {
            this.Dispatcher.Invoke(() =>
            {
                var formattedMessage = $"{user}: {message}";
                Console.WriteLine(formattedMessage);
                messagesList.Items.Add(formattedMessage);

            });
        });
    }
    //dispose ??
    private async void sendButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await _connection.InvokeAsync("SendMessage",
                userTextBox.Text, messageTextBox.Text);
        }
        catch (Exception ex)
        {
            messagesList.Items.Add(ex.Message);
        }
    }
}