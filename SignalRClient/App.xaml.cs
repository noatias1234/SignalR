using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
         HubConnection connection = new HubConnectionBuilder().Build();
    }
}
