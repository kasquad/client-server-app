using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;

namespace csharp_client
{
    class Program
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

        static void Main(string[] args)
        {
           
            using (WebSocket ws = new WebSocket("ws://localhost:4040/send/message"))
            {
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                Console.WriteLine("Connected to server");
                string data = string.Empty;
                while(true)
                {

                    Console.WriteLine("Enter message (if u want to disconnect type 'disconnect') : ");
                    data = Console.ReadLine();
                    if (data == "disconnect")
                        break;
                    Message msg = new Message(data);
                    ws.Send(JsonConvert.SerializeObject(msg));
                }
                ws.Close();
            }
            
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                 Console.WriteLine("Server taked message");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
