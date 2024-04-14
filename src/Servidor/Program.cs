using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        private int NumeroClientes ;

        public ClientHandler(TcpClient cliente, int numeroClientes)
        {
            this.Cliente = cliente;
            this.NumeroClientes = numeroClientes;
        }

        public void Handle() { }

    }
}

