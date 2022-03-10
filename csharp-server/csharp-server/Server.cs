using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using WebSocketSharp.Net;
using Newtonsoft.Json;


namespace csharp_server
{
    

    public class MessageService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Message msg = JsonConvert.DeserializeObject<Message>(e.Data);
            Console.WriteLine("Server: Received from client: " + msg.Text);
            Send("Server:message taken {" + msg.Text+ "}");
        }

        protected override void OnOpen()
        {
            string name = "testName";
            int IdClient = Server.clientManager.AddClient(name);
            int id = 0;
            Initializer initializer = new Initializer(1);
            Send(JsonConvert.SerializeObject(initializer));
            base.OnOpen();
        }
        protected override void OnClose(CloseEventArgs e)
        {

            base.OnClose(e);
        }
    }


    static class Server
    {
        public static ClientManager clientManager = new ClientManager();
        static void Main(string[] args)
        {
  
                WebSocketServer wssv = new WebSocketServer("ws://localhost:4040");
                wssv.AddWebSocketService<MessageService>("/send/message");
                wssv.Start();
                Console.WriteLine("Server started on ws://localhost:4040/send/message");

            
            do
                {
                    Console.WriteLine("If u want to stop  type 'stop'");
                } while (Console.ReadLine() != "stop");

                wssv.Stop();
          
        }
    }












   
       
}
