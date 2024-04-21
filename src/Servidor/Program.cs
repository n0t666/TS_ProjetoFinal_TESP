using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor
{
    internal class Program
    {
        private const int PORT = 10000;

        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endPoint);

            listener.Start();
            Console.WriteLine("SERVIDOR PRONTO!");
            int numeroClientes = 0;

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                numeroClientes++;
                Console.WriteLine("Cliente {0} connectou-se", numeroClientes);
                ClientHandler clientHandler = new ClientHandler(client, numeroClientes);
                clientHandler.Handle();
            }
        }


    }

    class ClientHandler
    {
        private TcpClient Cliente;
        private int IdCliente;

        public ClientHandler(TcpClient cliente, int idCliente)
        {
            this.Cliente = cliente;
            this.IdCliente = idCliente;
        }

        public void Handle()
        {
            Thread thread = new Thread(threadHandler);
            thread.Start();
        }

        private void threadHandler()
        {
            NetworkStream networkStream = this.Cliente.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();
            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0,
                    protocolSI.Buffer.Length);
                byte[] ack;
                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.DATA:
                        Console.WriteLine("Client " + IdCliente + ": " +
                            protocolSI.GetStringFromData());
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ack, 0, ack.Length);
                        break;

                    case ProtocolSICmdType.EOT:
                        Console.WriteLine("Ending Thread from Client {0}", IdCliente);
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ack, 0, ack.Length);
                        break;
                }
            }
            networkStream.Close();
            Cliente.Close();
        }
    }
}

