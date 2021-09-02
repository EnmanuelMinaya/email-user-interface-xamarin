using EmailUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailUserInterface.ViewModels
{
    public class MessageDetailViewModel : BaseViewModel
    {


        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public MessageDetailViewModel(Message message)
        {
            Sender = message.Sender;
            Receiver = message.Receiver;
            Subject = message.Subject;
            Body = message.Body;
            Date = message.Date;
        }
    }
}
