using System;
using System.IO;
using System.Collections.Generic;

namespace FileManager
{
    public class UI
    {
        private List<FileSystemInfo> _currentDirectoryContent;
        private ConsoleWindow _fileSystemWindow;
        private InfoFrame _currentPathFrame;
        private readonly InfoFrame[] _infoFrames =
        {
            new (0, Console.WindowHeight - 3, "[F1]: Help"),
            new (12, Console.WindowHeight - 3, "[F2]: Change folder"),
            new (33, Console.WindowHeight - 3, "[F3]: Add folder/file"), 
            new (56, Console.WindowHeight - 3, "[F4]: Delete folder/file"),
            new (82, Console.WindowHeight - 3, "[F5]: Refresh"),
            new (97, Console.WindowHeight - 3, "[Esc]: Exit"),
        };

        public UI()
        {
            Console.Title = "FileManager";
            Console.CursorVisible = false;
            CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _fileSystemWindow = new ConsoleWindow(0, 3, Console.WindowWidth - 1, Console.WindowHeight - 7);
            _currentDirectoryContent = GetCurrentDirectoryContent();
            _currentDirectoryContent.ForEach(e => _fileSystemWindow.Content.Add(e.Name));
            _currentPathFrame = new InfoFrame(0, 0, CurrentDirectory);

            Directory.SetCurrentDirectory(CurrentDirectory);
        }

        public string CurrentDirectory { get; private set; }

        public void HighlightNext() => _fileSystemWindow.HighlightNext();
        public void HighlightPrevious() => _fileSystemWindow.HighlightPrevious();
        public void ChangeDirectory()
        {
            CurrentDirectory = _currentDirectoryContent[_fileSystemWindow.TargetItem].FullName;
            _currentDirectoryContent = GetCurrentDirectoryContent();
            _currentPathFrame = new(_currentPathFrame.Location.X, _currentPathFrame.Location.Y, CurrentDirectory);
            _fileSystemWindow.ClearContent();
            _currentDirectoryContent.ForEach(e => _fileSystemWindow.Content.Add(e.Name));
        }
        /// <summary>
        /// Print UI elements content only.
        /// </summary>
        public void ContentUpdate()
        {
            _fileSystemWindow.PrintContent();
        }
        /// <summary>
        /// Clear console. Fully print all UI elements.
        /// </summary>
        public void Update()
        {
            Console.CursorVisible = false;
            Console.Clear();
            _fileSystemWindow.Print();
            _currentPathFrame.Print();
            Array.ForEach(_infoFrames, e => e.Print());
        }
        private List<FileSystemInfo> GetCurrentDirectoryContent()
        {
            EnumerationOptions options = new(){ AttributesToSkip = FileAttributes.Hidden };
            List<string> items = new(Directory.EnumerateFileSystemEntries(CurrentDirectory, "*", options));
            List<FileSystemInfo> fileSystemInfos = new();
            items.ForEach(e => fileSystemInfos.Add(new FileInfo(e)));

            return fileSystemInfos;
        }
    }
}
