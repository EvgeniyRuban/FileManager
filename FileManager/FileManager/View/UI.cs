using System;
using System.IO;
using System.Collections.Generic;

namespace FileManager.View
{
    internal sealed class UI
    {
        private List<FileSystemInfo> _currentDirectoryContent;
        private ConsoleWindow _fileSystemWindow;
        private InfoFrame _currentPathFrame;
        private readonly InfoFrame[] _infoFrames =
        {
            new (0, Console.WindowHeight - 3, "[F1]: Help"),
            new (12, Console.WindowHeight - 3, "[F2]:"),
            new (33, Console.WindowHeight - 3, "[F3]: Add folder/file"), 
            new (56, Console.WindowHeight - 3, "[F4]: Delete folder/file"),
            new (82, Console.WindowHeight - 3, "[F5]: Refresh"),
            new (97, Console.WindowHeight - 3, "[Esc]: Exit"),
        };

        public UI()
        {
            Console.Title = "FileManager";
            Console.CursorVisible = false;
            FileManager.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            CurrentDirectory = FileManager.GetCurrentDirectory();
            _fileSystemWindow = new ConsoleWindow(0, 3, Console.WindowWidth - 1, Console.WindowHeight - 7);
            _currentDirectoryContent = FileManager.GetCurrentDirectoryContent();
            _currentDirectoryContent.ForEach(e => _fileSystemWindow.AddContent(e.Name));
            AddParentDirectoryToList();
            _currentPathFrame = new InfoFrame(0, 0, CurrentDirectory);
        }

        public string CurrentDirectory { get; private set; }

        public string GetTargetItemPath() => _currentDirectoryContent[_fileSystemWindow.TargetItemIndex].FullName;
        public void HighlightNext() =>_fileSystemWindow.HighlightNext();
        public void HighlightPrevious() => _fileSystemWindow.HighlightPrevious();
        public void ChangeDirectory()
        {
            if (FileManager.TrySetCurrentDirectory(GetTargetItemPath()) != null)
            {
                return;
            }
            CurrentDirectory = GetTargetItemPath();
            _currentDirectoryContent = FileManager.GetCurrentDirectoryContent();
            _currentPathFrame = new(_currentPathFrame.Location.X, _currentPathFrame.Location.Y, CurrentDirectory);
            _fileSystemWindow.ClearContent();
            _currentDirectoryContent.ForEach(e => _fileSystemWindow.AddContent(e.Name));
            AddParentDirectoryToList();
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
        private void AddParentDirectoryToList()
        {
            if (FileManager.IsParentExist(CurrentDirectory))
            {
                string parentDirectoryDesignation = "...";
                DirectoryInfo parent = FileManager.GetParentDirectory(CurrentDirectory);
                _currentDirectoryContent.Insert(0, parent);
                _fileSystemWindow.Insert(0, parentDirectoryDesignation);
            }
        }
    }
}
