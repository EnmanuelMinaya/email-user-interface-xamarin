using EmailUserInterface.Models;
using EmailUserInterface.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmailUserInterface.ViewModels
{
    public class NewMessageViewModel : BaseViewModel
    {
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public ICommand AddCommand { get; }

        public ICommand AddImagePathCommand { get; }

        private ObservableCollection<Message> _inbox;
        
 
        public NewMessageViewModel(ObservableCollection<Message> inbox)
        {
            _inbox = inbox;



            AddImagePathCommand = new Command(async () => 
            {
                
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo == null)
                {
                    ImagePath = null;
                    return;
                }
                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                ImagePath = newFile;
            });


            AddCommand = new Command(async () =>
            {
                _inbox.Add(new Message(Sender, Receiver, Subject, DateTime.Now, Body, ImagePath));
                           
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}
