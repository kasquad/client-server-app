using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace csharp_server
{
    public class ClientManager
    {
        private Dictionary<int,IWebSocketSession> clients = new Dictionary<int, IWebSocketSession>();

        private int idClient = 0;
        private int IdClient { get { return idClient++; } }

        public int AddClient(ref IWebSocketSession session)
        {
            clients.Add(IdClient, session);
            Console.WriteLine(session.ID);
            session.Context.WebSocket.Send("Server:This session is inited");
            return 1;
        }

   
        public void SendAll()
        {
            Console.Write("SendAll to opened session: ");
            Console.WriteLine(clients.Where(k => k.Value.State == WebSocketSharp.WebSocketState.Open).
                                      Count()
                              );              

            foreach(KeyValuePair<int,IWebSocketSession> kvp in clients)
            {
                if(kvp.Value.State == WebSocketSharp.WebSocketState.Open)
                kvp.Value.Context.WebSocket.Send("Mass sending");
            }
        }


    }
}
