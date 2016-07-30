using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupercellProxy
{
    class ConsoleArgs
    {
        private readonly List<string> Arguments;

        /// <summary>
        /// The ConsoleArgs constructor 
        /// </summary>
        public ConsoleArgs(string[] args)
        {
            // string[] -> List<string>
            Arguments = new List<string>(args);
        }

        /// <summary>
        /// Parses console arguments
        /// </summary>
        public void Parse()
        {
            try
            {
                if (Arguments.Count != 1)
                    return;

                string Arg = Arguments[0];

                if(Arg == "-help" || Arg == "/help" || Arg == "help")
                {
                    Console.WriteLine("=> SupercellProxy - Argument usage <=");
                    Console.WriteLine("This proxy only accepts one console argument.");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("-help | /help | help -> Displays this.");
                    Console.WriteLine("-apk  | /apk  | apk  -> Downloads latest, modded game clients");
                    Program.Kill();
                }

                else if(Arg == "-apk" || Arg == "/apk" || Arg == "apk")
                {
                    APK_Downloader.Start();
                    Program.Kill();
                }

                else
                {
                    Console.WriteLine("Unknown argument.");
                    Program.Kill();
                }
            }
            catch(Exception ex)
            {
                Logger.Log("Failed to parse console arguments (" + ex.GetType() + ")!", LogType.EXCEPTION);
                Logger.Log("Please avoid passing invalid characters, this may be the cause of this exception.", LogType.EXCEPTION);
                Program.WaitAndKill();
            }
        }
    }
}