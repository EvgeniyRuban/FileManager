using System.Drawing;
using ConsoleCustomizer;

namespace FileManager
{
    internal abstract class ConsoleViewElement
    {
        protected ConsoleViewElement(Size size, Point location)
        {
            Size = size;
            Location = location;
        }
        protected ConsoleViewElement(int x, int y, int width, int height) : this(new Size(width, height), new Point(x, y))
        {
        }

        public Size Size { get; }
        public Point Location { get; }

        public virtual void Print() => CPainter.DrawDoubleLineFrame(Location, Size);
    }
}
