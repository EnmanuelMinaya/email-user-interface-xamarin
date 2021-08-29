using System;
using System.Collections.Generic;
using System.Text;

namespace EmailUserInterface.Models
{
    public class Email
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
