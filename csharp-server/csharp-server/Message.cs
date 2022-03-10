using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_server
{
    class Message
    {
        private int _ID;
        public int ID { get { return _ID; } }

        private string _text;
        public string Text { get { return _text; } }

        
        public Message(string text)
        {
            this._text = text;
        }
    }
}
