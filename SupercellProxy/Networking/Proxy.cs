using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace SupercellProxy
{
    class Proxy
    {
        public static List<Client> ClientPool = new List<Client>();

        /// <summary>
        /// Starts the proxy
        /// </summary>
        public static void Start()
        {
            try
            {
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+");
                Logger.Log("Game: " + Config.Game, LogType.CONFIG);
                Logger.Log("Host: " + Config.Host, LogType.CONFIG);
                Logger.Log("LogLevel: " + Config.LogLevel, LogType.CONFIG);
                Logger.Log("WebAPI Port: " + Config.WebAPI_PORT, LogType.CONFIG);
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+");
                Console.Write(Environment.NewLine);
                

                // Check directories
                if (!Directory.Exists("Logs"))
                    Directory.CreateDirectory("Logs");
                if (!Directory.Exists("Packets"))
                    Directory.CreateDirectory("Packets");

                // Download latest public key
                Keys.PublicKey();

                // Bind a new socket to the local EP     
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9339);
                Socket clientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientListener.Bind(endPoint);
                clientListener.Listen(100);

                // Listen for connections
                Logger.Log("Socket bound! Connect to " + Helper.LocalNetworkIP + " and you should be good to go.");
                new Thread(() =>
                {
                    while (true)
                    {
                        Socket clientSocket = clientListener.Accept();
                        Client client = new Client(clientSocket);
                        ClientPool.Add(client);

                        Logger.Log("Remote connection #" + (ClientPool.ToArray().Length) + " (" + client.ClientRemoteAdr + "), enqueuing..");
                        client.Enqueue();
                    }
                }).Start();
            }
            catch(Exception ex)
            {
                Logger.Log("Failed to start the proxy (" + ex.GetType() + ")!");
                Logger.Log("Please check if you use TCP and port 9339 at the Socket() constructor.");             
            }
        }

        /// <summary>
        /// Stops the proxy
        /// </summary>
        public static void Stop()
        {
            for (int i = 0; i < ClientPool.Count; i++)
            {
                ClientPool[i].Dequeue();
            }
            ClientPool.Clear();
        }
    }
}
