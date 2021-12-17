using System;

namespace FileManager
{
    public class UI
    {
        
        public UI()
        {
            Console.Title = "FileManager";
            Console.CursorVisible = false;
            FileSystemWindow = new FileSystemWindow();
        }


        public ConsoleWindow FileSystemWindow { get; set; }


        public void Draw()
        {
            Console.Clear();
            FileSystemWindow.Draw();
        }
    }
}
