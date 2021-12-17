using System;

namespace FileManager.Command
{
    public static class CommandHandler
    {
        public static void Run()
        {
            Command command = new UnknownCommand();
            do
            {
                Console.Clear();
                command = CommandParser.Parse(Console.ReadLine());
                Console.WriteLine(command.Info());
                Console.ReadKey();

            } while (command.Name == UserCommand.Unknown);

            CommandExecutor.Execute(command);
        }
    }
}