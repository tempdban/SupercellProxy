using System;
using System.IO;
using System.Text;

namespace SupercellProxy
{
    class Logger
    {
        /// <summary>
        /// The logger output stream
        /// </summary>
        public static StreamWriter OutputStream = new StreamWriter(Console.OpenStandardOutput())
        {
            AutoFlush = true,
            NewLine = Environment.NewLine
        };

        /// <summary>
        /// Logs passed text
        /// </summary>
        public static void Log(string text, LogType type = LogType.INFO)
        {
            if (Config.LogLevel == LogLevel.DEFAULT)
            {
                // Print line out
                switch (type)
                {
                    case LogType.INFO:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case LogType.WARNING:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case LogType.EXCEPTION:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogType.API:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case LogType.PACKET:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case LogType.PACKET_DATA:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case LogType.CONFIG:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                }

                Console.Write("[" + type + "] ");
                Console.ResetColor();
                Console.WriteLine(text);

                // Log line to file
                string path = Environment.CurrentDirectory + @"\\Logs\\" + DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy") + ".log";
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter StreamWriter = new StreamWriter(fs))
                    {
                        StreamWriter.WriteLine("[" + DateTime.UtcNow.ToLocalTime().ToString("hh-mm-ss") + "-" + type + "] " + text);
                        StreamWriter.Close();
                    }
                }
            }
        }
    }
}
