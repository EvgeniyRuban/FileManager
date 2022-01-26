using System.Drawing;
using ConsoleCustomizer;
using ConsoleCustomizer.Source;

namespace FileManager.View
{
    internal class Slider : ConsoleViewElement, IOrientable
    {
        public Slider(Point point, int length, int slideCount, Orientation orientation = Orientation.Vertical) :
            base(orientation == Orientation.Horizontal ? new(length, 1) : new(1, length), point)
        {
            Length = length;
            Orientation = orientation;
            SlidesCount = slideCount;
        }
        public Slider(int x, int y, int length, int slideCount, Orientation orientation = Orientation.Vertical)
            : this(new Point(x, y), length, slideCount, orientation)
        {
        }

        public Orientation Orientation { get; }
        public int Length { get; }
        public int TargetSlideIndex { get; private set; }
        public int SlidesCount { get; private set; }
        private int _slideLength
        {
            get
            {
                if (Length == 0)
                {
                    return 0;
                }
                else
                {
                    return Length % SlidesCount > 0 ? Length / SlidesCount + 1 : Length / SlidesCount;
                }
            }
        }

        public void SetSlidesCount(int count) => SlidesCount = count;
        public void SetSlideIndex(int index) => TargetSlideIndex = index >= 0 && index < SlidesCount ? index : TargetSlideIndex;
        public override void Print()
        {
            switch(Orientation)
            {
                case Orientation.Horizontal:
                    {
                        CPainter.DrawLine(Location.X, Location.Y, Location.X + Size.Width, Location.Y, OnceLineFrame.HorizontalLine);
                        if (TargetSlideIndex * _slideLength + _slideLength >= Size.Height)
                        {
                            int newSlideLength = _slideLength - (_slideLength + TargetSlideIndex * _slideLength - Size.Width);
                            CPainter.DrawLine(
                            Location.X + (TargetSlideIndex * _slideLength),
                            Location.Y,
                            Location.X + (TargetSlideIndex * _slideLength) + newSlideLength,
                            Location.Y,
                            CubeChar.Cube);
                        }
                        else
                        {
                            CPainter.DrawLine(
                            Location.X + (TargetSlideIndex * _slideLength),
                            Location.Y,
                            Location.X + (TargetSlideIndex * _slideLength) + _slideLength,
                            Location.Y,
                            CubeChar.Cube);
                        }
                        break;
                    }
                case Orientation.Vertical:
                    {
                        CPainter.DrawLine(Location.X, Location.Y, Location.X, Location.Y + Size.Height, OnceLineFrame.VerticalLine);
                        if (TargetSlideIndex * _slideLength + _slideLength >= Size.Height)
                        {
                            int newSlideLength = _slideLength - (_slideLength + TargetSlideIndex * _slideLength - Size.Height);
                            CPainter.DrawLine(
                            Location.X,
                            Location.Y + (TargetSlideIndex * _slideLength),
                            Location.X,
                            Location.Y + (TargetSlideIndex * _slideLength) + newSlideLength,
                            CubeChar.Cube);
                        }
                        else
                        {
                            CPainter.DrawLine(
                                Location.X,
                                Location.Y + (TargetSlideIndex * _slideLength),
                                Location.X,
                                Location.Y + (TargetSlideIndex * _slideLength) + _slideLength,
                                CubeChar.Cube);
                        }
                        break;
                    }
            }
        }
        public void Clear() => CPainter.FillRectangle(Location, Size);
    }
}
