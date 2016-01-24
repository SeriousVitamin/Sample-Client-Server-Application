using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Chat
    {
        private List<Message> _messages = new List<Message>();

        public Chat()
        {
            // todo Deserialize || works with database
        }

        public void AddMessage(string author, DateTime date, string text)
        {
            _messages.Add(new Message(author, date, text));
        }

        public string GetChatMessages(int count = 10)
        {
            var messages = _messages.OrderBy(m => m.Date);
            var sb = new StringBuilder();

            var from = messages.Count() - (count + 1);
            var to = messages.Count();

            for (int i = from; i < to; i++)
            {
                sb.Append("[" + _messages[i].Date + "] ");
                sb.Append(_messages[i].Author + ": ");
                sb.AppendLine(_messages[i].Text);
            }
            return sb.ToString();
        }
    }
}
