using System;
using System.Collections.Generic;
using System.Text;

namespace EmailUserInterface.Models
{
    public class Message
    {
        public Message(string sender, string receiver, string subject, DateTime date, string body)
        {
            Sender = sender;
            Receiver = receiver;
            Subject = subject;
            Date = date;
            Body = body;
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

    }
}
