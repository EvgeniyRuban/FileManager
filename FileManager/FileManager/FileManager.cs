using System;
using System.IO;
using System.Collections.Generic;

namespace FileManager
{
    internal sealed class FileManager
    {
        public static string TrySetCurrentDirectory(string path)
        {
            try
            {
                Directory.SetCurrentDirectory(path);
                return null;
            }
            catch(IOException ex)
            {
                return ex.Message;
            }
        }
        public static void SetCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);
        public static string GetCurrentDirectory() => Directory.GetCurrentDirectory();
        public static List<FileSystemInfo> GetCurrentDirectoryContent()
        {
            EnumerationOptions options = new() { AttributesToSkip = FileAttributes.Hidden };
            List<string> content = new(Directory.EnumerateFileSystemEntries(Directory.GetCurrentDirectory(), "*", options));
            List<FileSystemInfo> result = new();
            content.ForEach(e => result.Add(new FileInfo(e)));
            return result;
        }
        public static bool IsParentExist(string path) => Directory.GetParent(path) != null;
        public static DirectoryInfo GetParentDirectory(string path) => Directory.GetParent(path);
    }
}

