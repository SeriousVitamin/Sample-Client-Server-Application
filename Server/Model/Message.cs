using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Message
    {
        public string Author { get; private set; }
        public DateTime Date { get; private set; }
        public string Text { get; private set; }

        public Message(string author, DateTime date, string text)
        {
            Author = author;
            Date = date;
            Text = text;
        }
    }
}
