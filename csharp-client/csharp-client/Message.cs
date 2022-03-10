using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_client
{
    class Message
    {
        private string text;
        public string Text { get { return text; } }
        public Message(string text)
        {
            this.text = text;
        }
    }
}
