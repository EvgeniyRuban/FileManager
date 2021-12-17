using System;
using System.IO;

namespace FileManager
{
    public class FileSystemWindow : ConsoleWindow
    {
        public FileSystemWindow() : base
            (Console.WindowWidth - 1,
            Console.WindowHeight - 1,
            0,
            0)
        {
            DirectoryPath = Directory.GetCurrentDirectory();
            BorderColor = ConsoleColor.Gray;
            Text = Directory.EnumerateFileSystemEntries(Directory.GetCurrentDirectory());
        }


        public string DirectoryPath { get; set; } 
    }
}
