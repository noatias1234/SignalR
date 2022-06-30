using System;
using System.Windows.Input;

namespace SignalRClient
{
    internal class MessageCommand : ICommand
    {
        SignalRClientChat _signalRClientChat;

        public MessageCommand(SignalRClientChat signalRClientChat)
        {
           _signalRClientChat = signalRClientChat;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await 
        }

        public event EventHandler? CanExecuteChanged;
    }
}
