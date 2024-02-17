using System;
using System.IO;
namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();

            LogDel logDel = new LogDel(log.LogTextToFile);

            Console.WriteLine("Enter Your Name: ");
            var name = Console.ReadLine();
            //logDel(name);

            LogText(logDel, name);

            Console.ReadKey();
        }

        /*static void LogTextToString(string text)
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        static void LogTextToFile(string text)
        {
            using StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"stream.txt"),true);
            {
                writer.WriteLine($"{DateTime.Now} : {text}");
            }
        }*/

        class Log
        {
            public void LogTextToString(string text)
            {
                Console.WriteLine($"{DateTime.Now} : {text}");
            }

            public void LogTextToFile(string text)
            {
                using StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stream.txt"), true);
                {
                    writer.WriteLine($"{DateTime.Now} : {text}");
                }
            }
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }
}