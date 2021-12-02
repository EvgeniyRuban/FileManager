using System;

namespace FileManager.CommandHandler
{
    public static class CommandReader
    {
        public static void Read()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Input command:");

                var userRequest = CommandParser.Parse(Console.ReadLine());

                Console.WriteLine($"User command: {userRequest.Item1}");

                if (userRequest.Item2 != null)
                {
                    for (int i = 0; i < userRequest.Item2.Length; i++)
                    {
                        Console.WriteLine($"Context {i + 1}: {userRequest.Item2[i]}");
                    }
                }

            }while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
