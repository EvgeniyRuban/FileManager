﻿
namespace FileManager.Command
{
    internal enum UserCommand
    {
        Unknown = -1,
        ChangeCurrentDirectory,
        CreateDirectory,
        CreateFile,
        WriteToFile,
        Remove,
        Move,
        Rename
    }
}
