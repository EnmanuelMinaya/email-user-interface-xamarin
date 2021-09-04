using EmailUserInterface.Models;
using EmailUserInterface.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmailUserInterface.ViewModels
{
    public class InboxViewModel : BaseViewModel
    {




        public ObservableCollection<Message> Inbox { get; set; } = new ObservableCollection<Message>();




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
        

        public ICommand GoToNewMessageCommand { get; }
        public ICommand SelectedMessageCommand { get; }
        public ICommand DeleteCommand { get; }


        public InboxViewModel()
        {
            SelectedMessageCommand = new Command<Message>(OnSelectedMessage);

            GoToNewMessageCommand = new Command(OnNewMessage);
            DeleteCommand = new Command<Message>(OnDeleteMessage);
            
            string savedInbox = Xamarin.Essentials.Preferences.Get("list", "");
            if (savedInbox != "")
            {
                ObservableCollection<Message> inbox = JsonConvert.DeserializeObject<ObservableCollection<Message>>(savedInbox);
            }
        }
        private async void OnNewMessage()
        {

            await App.Current.MainPage.Navigation.PushAsync(new NewMessagePage(Inbox));
        }
        private async void OnSelectedMessage(Message message)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MessageDetailPage(message));
        }
        private void OnDeleteMessage(Message message)
        {
            Inbox.Remove(message);
        }
    }
}
