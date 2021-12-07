using System;
using FileManager.Command;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHandler.Run();

            Console.ReadKey();
        }
    }
}

