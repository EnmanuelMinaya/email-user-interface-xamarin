﻿using EmailUserInterface.Models;
using EmailUserInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmailUserInterface.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMessagePage : ContentPage
    {
        public NewMessagePage(ObservableCollection<Message> inbox)
        {
            InitializeComponent();
            BindingContext = new NewMessageViewModel(inbox);
        }
    }
}