using System.IO;

namespace FileManager.Command
{
    internal static class CommandExecutor
    {
        public static void Execute(Request request)
        {
            switch (request.Command)
            {
                case UserCommand.ChangeCurrentDirectory:
                    {
                        Directory.SetCurrentDirectory(null);
                        break;
                    }
                case UserCommand.CreateDirectory:
                    {
                        Directory.CreateDirectory(null);
                        break;
                    }
                case UserCommand.CreateFile:
                    {
                        File.Create(null);
                        break;
                    }
                case UserCommand.WriteToFile:
                    {
                        File.AppendAllText(null, null);
                        break;
                    }
                case UserCommand.Remove:
                    {
                        Directory.Delete(null);
                        break;
                    }
                case UserCommand.Move:
                    {
                        Directory.Move(null, null);
                        break;
                    }
                case UserCommand.Rename:
                    {
                        // создать новую директорию/файл с новым именем
                        break;
                    }
            }
        }
    }
}
