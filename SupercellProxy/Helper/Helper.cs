using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SupercellProxy
{
    class Helper
    {
        /// <summary>
        /// Returns the local network IP in a proper format
        /// </summary>
        public static IPAddress LocalNetworkIP
        {
            get
            {
                try
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        socket.Connect("10.0.2.4", 65530);
                        return (socket.LocalEndPoint as IPEndPoint).Address;
                    }
                }
                catch
                {
                    return IPAddress.Parse("127.0.0.1");
                }                
            }
        }

        /// <summary>
        /// Returns Proxy-Version in the following format:
        /// v1.2.3
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(5);
            }
        }

        /// <summary>
        /// Returns the actual time in a localized format
        /// </summary>
        public static string ActualTime
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Checks if the proxy runs on Mono
        /// </summary>
        public static void CheckMono()
        {
            if (Type.GetType("Mono.Runtime") != null)
            {
                Logger.Log("This proxy does not support Mono and will likely throw exceptions!", LogType.WARNING);
                Logger.Log("Please proceed with caution!", LogType.WARNING);
                Console.WriteLine("Proceed (y/n)?");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        // Continue
                        break;
                    case ConsoleKey.N:
                        // Exit
                        Program.Kill();
                        break;
                    default:
                        // Exit
                        Program.Kill();
                        break;
                }
            }
        }        
    }
}
