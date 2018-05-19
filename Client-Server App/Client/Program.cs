using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool t = false;

            while (!t)
            {
                Console.WriteLine("What Protocol Type Do you want to use");
                Console.WriteLine("  1 : TCP");
                Console.WriteLine("  2 : UDP");
                Console.WriteLine("Press 1 or 2");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    t = true;
                    MyTCPClient tcp = new MyTCPClient();
                    tcp.CreateClient();
                }
                else if (choose == 2)
                {
                    t = true;
                    MyUDPClient udp = new MyUDPClient();
                    udp.CreateClient();
                }
            }
        }
    }
}
