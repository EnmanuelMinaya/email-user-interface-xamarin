using EmailUserInterface.Models;
using EmailUserInterface.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmailUserInterface.ViewModels
{
    public class InboxViewModel : BaseViewModel
    {
        private Message _selectedMessage;
        public Message SelectedMessage 
        { 
            get 
            {
                return _selectedMessage;
            }
            set
            {
                _selectedMessage = value;
                if (_selectedMessage != null)
                {
                    SelectedMessageCommand.Execute(_selectedMessage);
                }
            }
        }
        
        public ObservableCollection<Message> Inbox { get; } = new ObservableCollection<Message>()
        {
        }; 
        public ICommand GoToNewMessageCommand { get; }
        public ICommand SelectedMessageCommand { get; }
        public ICommand DeleteCommand { get; }


        public InboxViewModel()
        {
            SelectedMessageCommand = new Command<Message>(OnSelectedMessage);

            GoToNewMessageCommand = new Command(OnNewMessageCommand);
            DeleteCommand = new Command<Message>(OnDeleteMessageCommand);
        }
        private async void OnNewMessageCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewMessagePage(Inbox));
        }
        private async void OnSelectedMessage(Message message)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MessageDetailPage(message));
        }
        private void OnDeleteMessageCommand(Message message)
        {
            Inbox.Remove(message);
        }
    }
}
