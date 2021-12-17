using System.IO;

namespace FileManager.Command
{
    internal static class CommandExecutor
    {
        public static void Execute(Command command)
        {
            switch (command.Name)
            {
                case UserCommand.ChangeCurrentDirectory:
                    {
                        Directory.SetCurrentDirectory(command.Arguments[0]);
                        break;
                    }
                case UserCommand.CreateDirectory:
                    {
                        Directory.CreateDirectory(command.Arguments[0]);
                        break;
                    }
                case UserCommand.CreateFile:
                    {
                        File.Create(command.Arguments[0]);
                        break;
                    }
                case UserCommand.WriteToFile:
                    {
                        File.AppendAllText(command.Arguments[0], command.Arguments[1]);
                        break;
                    }
                case UserCommand.Remove:
                    {
                        Directory.Delete(command.Arguments[0]);
                        break;
                    }
                case UserCommand.Move:
                    {
                        Directory.Move(command.Arguments[0], command.Arguments[1]);
                        break;
                    }
                case UserCommand.Rename:
                    {
                        Directory.Delete(command.Arguments[0]);
                        Directory.CreateDirectory(command.Arguments[1]);
                        break;
                    }
            }
        }
    }
}
