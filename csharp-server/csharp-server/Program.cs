using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;


namespace csharp_server
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


    public class MessageService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Message msg = JsonConvert.DeserializeObject<Message>(e.Data);
            Console.WriteLine("Server: Received from client: " + msg.Text);
            Send("Server:message taken {" + msg.Text+ "}");


        }
    }

    class Program
    {
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
