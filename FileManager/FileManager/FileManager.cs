using System;

namespace FileManager
{
    internal class FileManager
    {
        public void Run()
        {
            UI ui = new UI();
            ui.Draw();
            ConsoleKeyInfo input = new ();
            bool canExit = false;
            do
            {
                ui.Draw();
                input = Console.ReadKey(true);

                switch(input.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            ui.FileSystemWindow.TargetStrip++;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            ui.FileSystemWindow.TargetStrip--;
                            break;
                        }
                    case ConsoleKey.Enter: // Pick
                        {

                            break;
                        }
                    case ConsoleKey.Escape: // Exit
                        {
                            canExit = true;
                            break;
                        }
                }

            } while (!canExit);
        }
    }
}
