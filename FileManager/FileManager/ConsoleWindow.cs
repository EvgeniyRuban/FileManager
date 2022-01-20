using System;
using System.Drawing;
using System.Collections.Generic;
using ConsoleCustomizer;

namespace FileManager
{
    internal class ConsoleWindow : ConsoleViewElement
    {
        public ConsoleWindow(Size size, Point location) : base(size, location)
        {
            Content = new();
        }
        public ConsoleWindow(int x, int y, int width, int height) : this(new Size(width, height), new Point(x, y))
        {
        }

        public List<string> Content { get; set; }
        public int TargetItem { get; private set; }

        public void HighlightNext() => _ = TargetItem != Content.Count - 1 ? TargetItem++ : TargetItem = 0;
        public void HighlightPrevious() => _ = TargetItem != 0 ? TargetItem-- : TargetItem = Content.Count - 1;
        public override void Print()
        {
            base.Print();
            PrintContent();
        }
        public void ClearContent() => Content.Clear();
        public void ClearWindow() => CPainter.FillRectangle(Location.X + 1, Location.Y + 1, Size.Width - 1, Size.Height - 1);
        public void PrintContent()
        {
            int textPositionX = Location.X + 1;
            int textPositionY = Location.Y + 1;

            for(int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(textPositionX, textPositionY++);
                if(i == TargetItem)
                {
                    SwapBackAndForegroundColors();
                    Console.Write(Content[i]);
                    SwapBackAndForegroundColors();
                    continue;
                }
                Console.Write(Content[i]);
            }
        }
        private void SwapBackAndForegroundColors()
        {
            var temp = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = temp;
        }
    }
}
