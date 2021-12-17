using System;
using System.Collections.Generic;

namespace FileManager.Command
{
    internal static class CommandParser
    {
        private static readonly Dictionary<string, Command> _commands = new()
        {
            { "cd", new ChangeDirectoryCommand() },
            { "mkdir", new CreateDirectoryCommand() },
            { "touch", new CreateFileCommand() },
            { "cat", new WriteToFileCommand() },
            { "rm", new RemoveCommand() },
            { "move", new MoveCommand() },
            { "rename", new RenameCommand() },
        };


        /// <summary>
        /// The method searches for commands and context from user request.
        /// </summary>
        /// <returns>Commands and context array</returns>
        public static Command Parse(string request)
        {
            return CommandSearch(request);
        }


        private static Command CommandSearch(string s)
        {
            if (s == null || s == string.Empty) 
            { 
                return new UnknownCommand(); 
            }

            Command command = new UnknownCommand();
            string[] input = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int keyWordPosition = 0;
            input[keyWordPosition] = input[keyWordPosition].ToLower();

            if (_commands.ContainsKey(input[keyWordPosition]))
            {
                int inputArgsCount = input.Length - 1;
                command = _commands[input[keyWordPosition]];

                if (inputArgsCount == command.ArgsCount)
                {
                    command.Arguments = new string[input.Length - 1];
                    for(int i = 1; i < input.Length; i++)
                    {
                        command.Arguments[i - 1] = input[i];
                    }
                }
                else
                {
                    return new UnknownCommand();
                }
            }

            return command; ;
        }
    }
}
