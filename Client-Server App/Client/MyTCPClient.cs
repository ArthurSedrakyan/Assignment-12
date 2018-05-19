using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MyTCPClient
    {
        public void CreateClient()
        {
            //"192.168.1.5"


            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));

            while (true)
            {
                //Read text
                Console.WriteLine("Use this format operator: first_value:second_value");
                string text = Console.ReadLine();
                while (text.Equals(""))
                {
                    Console.Write("Repeat");
                    text = Console.ReadLine();
                }

                byte[] data = Encoding.UTF8.GetBytes(text);

                //send text
                socket.Send(data);

                if (text.Equals("close"))
                {
                    socket.Close();
                    break;
                }


                byte[] buffer = new byte[1024];
                int bytes = socket.Receive(buffer);
                text = Encoding.UTF8.GetString(buffer, 0, bytes);

                Console.WriteLine(text);
            }
        }

    }
}
