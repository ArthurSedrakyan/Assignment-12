using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class MyUDPClient
    {
        public void CreateClient()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ipAdress, 1235);


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

                if (text.Equals("close"))
                {
                    client.Close();
                    break;
                }


                byte[] data = Encoding.UTF8.GetBytes(text);

                //send text
                client.SendTo(data, endPoint);



                EndPoint endPoinFrom = new IPEndPoint(IPAddress.Any, 1235);
                var bytes = client.ReceiveFrom(data,ref endPoinFrom);

                text = Encoding.UTF8.GetString(data, 0, bytes);

                Console.WriteLine(text);
            }
        }
    }
}
