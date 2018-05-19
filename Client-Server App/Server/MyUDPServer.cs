using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class MyUDPServer
    {
        private UdpClient listener;
        private IPEndPoint groupEP;

        public MyUDPServer()
        {
            listener = new UdpClient(1235);
            groupEP = new IPEndPoint(IPAddress.Any, 1235);
        }
        public void CreateServer()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = listener.Receive(ref groupEP);
                    Console.WriteLine($"The {groupEP.Address.ToString()} Client connected");


                    Task.Run(() => Start(buffer));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }

        }
        private void Start(byte[] buffer)
        {

            string msg = (Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            var args = msg.Split(':');

            MathServer mathServer = new MathServer();
            double firsValue = Convert.ToDouble(args[1]);
            double secondValue = Convert.ToDouble(args[2]);
            double result = 0;

            switch (args[0])
            {
                case "+":
                    result = mathServer.Add(firsValue, secondValue);
                    break;
                case "-":
                    result = mathServer.Sub(firsValue, secondValue);
                    break;
                case "/":
                    result = mathServer.Div(firsValue, secondValue);
                    break;
                case "*":
                    result = mathServer.Mult(firsValue, secondValue);
                    break;
                default:
                    Console.WriteLine("you write Wrong operation!!");
                    return;
            }

            buffer = Encoding.UTF8.GetBytes(result.ToString());
            listener.Send(buffer, buffer.Length, groupEP);
        }
    }
}
