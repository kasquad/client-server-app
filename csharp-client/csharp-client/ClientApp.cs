﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;

namespace csharp_client
{
    
    static class ClientApp
    {
        static public Client client = new Client();

        static void Main(string[] args)
        {
            using (WebSocket ws = new WebSocket("ws://localhost:4040/send/message"))
            {
                
                ws.OnMessage += Ws_OnMessage;
                ws.OnOpen += Ws_OnOpen;
                ws.Connect();

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
     

        private static void Ws_OnOpen(object sender, EventArgs e)
        {
            
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (!ClientApp.client.IsInitialized)
            {
                ClientApp.client.Init(e.Data);
            }
          

        }
    }
}
