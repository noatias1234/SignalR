using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client;

public partial class MainWindow : Window
{
    readonly HubConnection _connection;
    public MainWindow()
    {
        InitializeComponent();

        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5094/chatHub")
            .Build();

        // When connection is closed (disconnected) wait delay before start
        _connection.Closed += async (_) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        };
 
          _connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            this.Dispatcher.Invoke(() =>
            {
                var newMessage = $"{user}: {message}";
                messagesList.Items.Add(newMessage);
            });
        });

        try
        {
            _connection.StartAsync();
            messagesList.Items.Add("Connection started");
            sendButton.IsEnabled = true;
        }
        catch (Exception ex)
        {
            messagesList.Items.Add(ex.Message);
        }
    }

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