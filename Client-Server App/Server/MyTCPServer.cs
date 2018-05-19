using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MyTCPServer
    {
        public void CreateServer()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var localEndPoint = new IPEndPoint(IPAddress.Any, 1234);

            socket.Bind(localEndPoint);
            socket.Listen(100);

            while (true)
            {
                var clientSocket = socket.Accept();
                Console.WriteLine("Client connected");

                Task.Run(() => Start(clientSocket));
            }
        }

        private void Start(Socket clientSocket)
        {
            while (true)
            {
                byte[] buffer = new byte[clientSocket.SendBufferSize];

                int bytes = clientSocket.Receive(buffer);
                string msg = (Encoding.UTF8.GetString(buffer, 0, bytes));


                if (msg.Equals("close"))
                {
                    clientSocket.Close();
                    return;
                }
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
                clientSocket.Send(buffer);
            }
        }
    }
}
