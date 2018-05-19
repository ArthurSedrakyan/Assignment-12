using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTCPServer myTCP = new MyTCPServer();
            Task.Run(() => myTCP.CreateServer());
            MyUDPServer myUDP = new MyUDPServer();
            myUDP.CreateServer();
        }
    }
}
