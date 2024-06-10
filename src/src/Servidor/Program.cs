using EI.SI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente
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
            string msg;

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                numeroClientes++;
                msg = string.Format("Cliente {0}: connectou-se ({1})", numeroClientes, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
                Console.WriteLine(msg);
                ClientHandler clientHandler = new ClientHandler(client, numeroClientes);
                clientHandler.Log(msg);
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

        // Método para escrever no ficheiro log.txt com os eventos do servidor na pasta root do projeto
        public void Log(string msg)
        {
            string nomeFicheiro = "log.txt";
            string rootProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")); // Subir duas pastas para a raiz do projeto
            string caminho = Path.Combine(rootProjeto, nomeFicheiro);
            using (StreamWriter w = File.AppendText(caminho))
            {
                w.WriteLine(msg);
            }
        }

        private void threadHandler()
        {
            NetworkStream networkStream = this.Cliente.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();
            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0,protocolSI.Buffer.Length);
                byte[] ack;
                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.DATA:
                        string mensagem = protocolSI.GetStringFromData();
                        string msg = string.Format("Cliente {0}: enviou uma mensagem ({1})", IdCliente, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
                        Console.WriteLine(msg);
                        Log(msg);
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ack, 0, ack.Length);
                        break;

                    case ProtocolSICmdType.EOT:
                        string msgEOT = string.Format("Cliente {0}: disconectou-se ({1})", IdCliente, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
                        Console.WriteLine(msgEOT);
                        Log(msgEOT);
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

