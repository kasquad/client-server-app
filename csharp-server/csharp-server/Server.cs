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
            Console.WriteLine("Client {0}: {1}", ID, e.Data);
        }
        
        protected override void OnOpen()
        {
            base.OnOpen();
            try
            {
                IWebSocketSession session;
                if (!Sessions.TryGetSession(ID, out session))
                    throw new Exception();
                Server.clientManager.AddClient (ref session);
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
  
        }
        protected override void OnClose(CloseEventArgs e)
        {
            try
            {
                IWebSocketSession sess;
                if (!Sessions.TryGetSession(ID, out sess))
                    throw new Exception();
                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            IWebSocketSession session;

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
                    Console.ReadKey();
                clientManager.SendAll();
                
                } while (Console.ReadLine() != "stop");

                wssv.Stop();
          
        }
    }












   
       
}
