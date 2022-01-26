using System;
using System.Drawing;

namespace FileManager.View
{
    internal sealed class InfoFrame : ConsoleViewElement
    {
        public readonly string Content;

        public InfoFrame(Point location, string info) : base(new (info.Length + 1, 2), location)
        {
            Content = info;
        }
        public InfoFrame(int x, int y, string info) : this ( new (x, y), info)
        {
        }

        public override void Print()
        {
            base.Print();
            Console.SetCursorPosition(Location.X + 1, Location.Y + 1);
            Console.Write(Content);
        }
    }
}
