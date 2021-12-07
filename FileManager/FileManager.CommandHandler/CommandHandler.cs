using System;

namespace FileManager.Command
{
    public static class CommandHandler
    {
        public static void Run()
        {
            Request request = new(CommandParser.Parse(Console.ReadLine()));
            CommandExecutor.Execute(request);
        }
    }
}
