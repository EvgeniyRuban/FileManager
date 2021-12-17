using System;
using System.Drawing;
using System.Collections.Generic;

namespace FileManager
{
    public abstract class ConsoleWindow
    {
        protected ConsoleWindow(int width, int height, int x, int y) : this(new Size(width, height), new Point(x,y))
        {
        }
        protected ConsoleWindow(Size size, Point position)
        {
            Size = size;
            Position = position;
        }


        public Size Size { get; set; }
        public Point Position { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public IEnumerable<string> Text { get; set; }
        public byte TargetStrip { get; set; }


        public void Draw()
        {
            ConsoleGraphics.FillRectangle(Position, Size, Console.BackgroundColor);
            ConsoleGraphics.FillRectangle(Position, Size, BackgroundColor);
            ConsoleGraphics.DrawRectangle(Position, Size, BorderColor);
            PrintText();

        }

        private void PrintText()
        {
            int textPositionX = Position.X + 1;
            int textPositionY = Position.Y + 1;
            var temp = Console.BackgroundColor;
            Console.BackgroundColor = BackgroundColor;

            foreach (var strip in Text)
            {
                Console.SetCursorPosition(textPositionX, textPositionY++);
                Console.Write(strip);
            }
            Console.BackgroundColor = temp;
        }
    }
}
