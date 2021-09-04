using EmailUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailUserInterface.ViewModels
{
    public class MessageDetailViewModel 
    {


        public string Sender { get; }
        public string Receiver { get; }
        public string Subject { get; }
        public string Body { get; }
        public DateTime Date { get; }
        public string ImagePath { get; set; }


        public MessageDetailViewModel(Message message)
        {
            Sender = message.Sender;
            Receiver = message.Receiver;
            Subject = message.Subject;
            Body = message.Body;
            Date = message.Date;
            ImagePath = message.ImagePath;
        }
    }
}
