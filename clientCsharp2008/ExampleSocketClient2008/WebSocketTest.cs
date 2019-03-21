using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebex.Net;

namespace ExampleSocketClient2008
{

    public class WebSocketTest
    {
        
        public delegate void dgEventRaiser(String message);
        public event dgEventRaiser onNotification;
        
        public delegate void dgEventNewMessage(String message);
        public event dgEventNewMessage onNewMessage;

        String uri;
        public WebSocketClient client;
        public WebSocketTest(string uri)
        {
            this.uri = uri;
            this.client = new WebSocketClient();            
        }
        public void send(String message)
        {
            this.onNotification("Sending message...");
            this.client.Send(message);
        }
        public void conectar()
        {            
            this.client.Connect(this.uri);
            this.onNotification("Connecting...");            

            System.Threading.Thread beginReadThread = new System.Threading.Thread(new System.Threading.ThreadStart(beginRead));
            beginReadThread.Start();
                        
        }

        public void beginRead(){
            String response = null;
            while (true)
            {
                response = this.client.Receive<String>();
                this.onNewMessage(response);            
            }
        }

    }
}
