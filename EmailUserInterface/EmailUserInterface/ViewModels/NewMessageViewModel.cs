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
    public class NewMessageViewModel : BaseViewModel
    {
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public ICommand AddCommand { get; }

        public NewMessageViewModel(ObservableCollection<Message> inbox)
        {
            _inbox = inbox;

            AddCommand = new Command(async () =>
            {
                _inbox.Add(new Message(Sender, Receiver, Subject, DateTime.Now, Body));
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }

        public NewMessageViewModel()
        {
            //Constructor sin parametros necesario para seleccionar binding context en el XAML
        }

        private ObservableCollection<Message> _inbox;

    }
}
