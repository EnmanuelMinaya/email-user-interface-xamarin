using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmailUserInterface.ViewModels
{
    public class InboxViewModel : BaseViewModel
    {



        public ICommand GoToNewMessageCommand { get; }

        public InboxViewModel()
        {

        }
    }
}
