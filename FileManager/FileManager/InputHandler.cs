using System;
using FileManager.View;

namespace FileManager
{
    internal static class InputHandler
    {
        private static FileManager _fileManager = new();
        private static UI _ui = new();

        private static void Run()
        {
            bool canExit = false;
            ConsoleKeyInfo input = new();
            _ui.Update();
            do
            {
                input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Enter: // Enter folder
                        {
                            _ui.ChangeDirectory();
                            _ui.Update();
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            _ui.HighlightPrevious();
                            _ui.ContentUpdate();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            _ui.HighlightNext();
                            _ui.ContentUpdate();
                            break;
                        }
                    case ConsoleKey.Escape: // Exit
                        {
                            canExit = true;
                            break;
                        }
                    case ConsoleKey.F1: // Help
                        {
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            break;
                        }
                    case ConsoleKey.F3: // Add
                        {
                            break;
                        }
                    case ConsoleKey.F4: // Delete
                        {
                            break;
                        }
                    case ConsoleKey.F5: // Refresh
                        {
                            _ui.Update();
                            break;
                        }
                }

            } while (!canExit);
        }
        public static void Main(string[] args) => Run();
        
    }
}
