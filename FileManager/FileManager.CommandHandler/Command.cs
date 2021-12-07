using System;
using System.Text;

namespace FileManager.Command
{
    internal abstract class Command
    {
        protected string[] _arguments;


        public readonly UserCommand Name;

        public readonly byte ArgsCount;


        protected Command(UserCommand command, byte argumentsCount)
        {
            Name = command;
            ArgsCount = argumentsCount;
        }


        public string[] Arguments 
        {
            get => _arguments;
            set
            {
                if (value.Length > ArgsCount)
                    throw new ArgumentException();

                _arguments = value;
            }
        }


        public string Info()
        {
            StringBuilder result = new($"Command name: {Name}\n");

            if (ArgsCount != 0)
            {
                for (int i = 0; i < Arguments.Length; i++)
                {
                    result.Append($"Context {i + 1}: {Arguments[i]}\n");
                }
            }

            return result.ToString();
        }
    }


    internal class UnknownCommand : Command
    {
        public UnknownCommand() : base(UserCommand.Unknown, 0)
        {
        }
    }


    internal class ChangeDirectoryCommand : Command
    {
        public ChangeDirectoryCommand() : base(UserCommand.ChangeCurrentDirectory, 1)
        {
        }
    }


    internal class CreateDirectoryCommand : Command
    {
        public CreateDirectoryCommand() : base(UserCommand.CreateDirectory, 1)
        {
        }
    }


    internal class CreateFileCommand : Command
    {
        public CreateFileCommand() : base(UserCommand.CreateFile, 1)
        {
        }
    }


    internal class WriteToFileCommand : Command
    {
        public WriteToFileCommand() : base(UserCommand.WriteToFile, 2)
        {
        }
    }


    internal class RemoveCommand : Command
    {
        public RemoveCommand() : base(UserCommand.Remove, 1)
        {
        }
    }


    internal class MoveCommand : Command
    {
        public MoveCommand() : base(UserCommand.Move, 2)
        {
        }
    }


    internal class RenameCommand : Command
    {
        public RenameCommand() : base(UserCommand.Rename, 2)
        {
        }
    }
}
