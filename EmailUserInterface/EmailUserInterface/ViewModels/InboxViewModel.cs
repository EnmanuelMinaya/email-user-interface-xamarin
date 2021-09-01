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


        public ObservableCollection<Message> Inbox { get; } = new ObservableCollection<Message>()
        {
            new Message("Ryan","Claudia","Receta",DateTime.Now,"Limon y menta"),
            new Message("Ryan","Claudia","Receta",DateTime.Now,"Limon y menta")

        }; 
        public ICommand GoToNewMessageCommand { get; }
           
        public InboxViewModel()
        {
            GoToNewMessageCommand = new Command(OnNewMessageCommand);
        }
        private async void OnNewMessageCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewMessagePage(Inbox));
        }
    }
}
