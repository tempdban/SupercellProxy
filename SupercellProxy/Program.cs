using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SupercellProxy
{
    class Program
    {
        /// <summary>
        /// Entry point for the program
        /// </summary>
        public static void Main(string[] args)
        {
            // Parse console arguments
            new ConsoleArgs(args).Parse();

            // Setup console parameters
            Console.Title = "Supercell Proxy " + Helper.AssemblyVersion + " | © 2016 InfinityModding";
            Console.SetOut(Logger.OutputStream);

            // Check whether the proxy runs on a linux/mac system
            Helper.CheckMono();

            // Start the proxy
            Proxy.Start();

            // Start the WebAPI
            WebAPI.Start();
            
        }

        /// <summary>
        /// Kills the program
        /// </summary>
        public static void Kill()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Waits a certain amount of seconds and kills the program
        /// </summary>
        public static void WaitAndKill()
        {
            Thread.Sleep(1350);
            Environment.Exit(0);
        }

        /// <summary>
        /// Restarts the program
        /// </summary>
        public static void Restart()
        {
            Process.Start(Assembly.GetExecutingAssembly().Location);
            Environment.Exit(0);
        }
    }
}