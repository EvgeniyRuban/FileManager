using System;
using System.Collections.Generic;

namespace FileManager.CommandHandler
{
    internal static class CommandParser
    {
        private static readonly Dictionary<string, UserCommand> _commands = new()
        {
            { "cd", UserCommand.ChangeCurrentDirectory },
            { "mkdir", UserCommand.CreateDirectory },
            { "touch", UserCommand.CreateFile },
            { "cat", UserCommand.WriteToFile },
            { "rm", UserCommand.Remove },
            { "move", UserCommand.Move },
            { "rename", UserCommand.Rename },
        };


        /// <summary>
        /// The method searches for commands and context from user request.
        /// </summary>
        /// <returns>Commands and context array</returns>
        public static (UserCommand, string[]) Parse(string request) => CommandSearch(request);


        private static (UserCommand, string[]) CommandSearch(string s)
        {
            if (s == null) 
            { 
                return (UserCommand.Unknown, null); 
            }

            (UserCommand, string[]) result = (UserCommand.Unknown, null);
            string[] input = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(input.Length > 0)
            {
                input[0] = input[0].ToLower();
            }

            if (_commands.ContainsKey(input[0]))
            {
                result.Item1 = _commands[input[0]];

                if (input.Length > 1)
                {
                    result.Item2 = new string[input.Length - 1];
                    for(int i = 1; i < input.Length; i++)
                    {
                        result.Item2[i - 1] = input[i];
                    }
                }
            }

            return result;
        }
    }
}
