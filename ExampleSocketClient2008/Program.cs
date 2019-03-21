using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ExampleSocketClient2008
{
    class Program
    {

        static void Main(string[] args)
        {
            
            // WebSocketTest ws = new WebSocketTest("wss://192.168.0.13:8080");
            //WebSocketTest ws = new WebSocketTest("wss://demos.kaazing.com/echo");
            WebSocketTest ws = new WebSocketTest("ws://echo.websocket.org/");

            ws.onNotification += onNotifications;
            ws.onNewMessage += onNewMessage;     
            ws.conectar();
            ws.send("Hello, I  am VS2008!");

            
        }
        static void onNewMessage(String message)
        {
            Console.WriteLine("Arrived new message: " + message);
        }
        static void onNotifications(String message)
        {
            Console.WriteLine(message);
        }
    }

}
