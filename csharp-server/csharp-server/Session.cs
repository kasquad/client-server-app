using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Net.WebSockets;
using WebSocketSharp.Server;

namespace csharp_server
{
    class Session : IWebSocketSession
    {
        public WebSocketContext Context => throw new NotImplementedException();

        public string ID => throw new NotImplementedException();

        public string Protocol => throw new NotImplementedException();

        public DateTime StartTime => throw new NotImplementedException();

        public WebSocketState State => throw new NotImplementedException();
    }
}
