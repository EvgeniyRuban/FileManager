using System;
using System.Drawing;
using System.Linq;
using ConsoleCustomizer;

namespace FileManager.View
{
    internal sealed class ConsoleWindow : ConsoleViewElement
    {
        private ScrollableCollection<string> _content;
        private Slider _slider;

        public ConsoleWindow(Size size, Point location) : base(size, location)
        {
            _content = new(size.Height - 1);
            _slider = new Slider(location.X + size.Width - 1, location.Y + 1, size.Height - 2, 1);
        }
        public ConsoleWindow(int x, int y, int width, int height) : this(new Size(width, height), new Point(x, y))
        {
        }

        public int TargetItemIndex { get; private set; }
        public string TargetItemContent => _content[TargetItemIndex];
        private bool _sliderVisible => _content.SlidesCount > 1;

        public void HighlightNext()
        {
            if(TargetItemIndex != _content.CurrentSlideContentCount - 1)
            {
                TargetItemIndex++;
            }
            else
            {
                if (_content.CurrentSlideIndex != _content.SlidesCount - 1)
                {
                    _content.ScrollDown1();
                    TargetItemIndex = 0;
                    _slider.SetSlideIndex(_content.CurrentSlideIndex);
                    ClearWindow();
                    PrintContent();
                }
            }
        }
        public void HighlightPrevious()
        {
            if(TargetItemIndex != 0)
            {
                TargetItemIndex--;
            }
            else
            {
                if(_content.CurrentSlideIndex != 0)
                {
                    _content.ScrollUp1();
                    TargetItemIndex = _content.CurrentSlideContentCount - 1;
                    _slider.SetSlideIndex(_content.CurrentSlideIndex);
                    ClearWindow();
                    PrintContent();
                }
            }
        }
        public void AddContent(params string[] items)
        {
            _content.Add(items.ToList());
            _slider.SetSlidesCount(_content.SlidesCount);
            _slider.SetSlideIndex(_content.CurrentSlideIndex);
            TargetItemIndex = 0;
        }
        public void Insert(int index, string content)
        {
            _content.Insert(index, content);
            _slider.SetSlidesCount(_slider.SlidesCount + 1);
            _slider.SetSlideIndex(_content.CurrentSlideIndex);
        }
        public void ScrollUp1() => _content.ScrollUp();
        public void ScrollDown1() => _content.ScrollDown();
        public override void Print()
        {
            base.Print();
            PrintContent();
        }
        public void ClearContent()
        {
            _content.Clear();
            _slider.Clear();
            TargetItemIndex = 0;
        }
        public void ClearWindow() => CPainter.FillRectangle(Location.X + 1, Location.Y + 1, Size.Width - 1, Size.Height - 1);
        public void PrintContent()
        {
            int textPositionX = Location.X + 1;
            int textPositionY = Location.Y + 1;

            for(int i = 0; i < _content.CurrentSlideContentCount; i++)
            {
                Console.SetCursorPosition(textPositionX, textPositionY++);
                if(i == TargetItemIndex)
                {
                    SwapBackAndForegroundColors();
                    Console.Write(_content[i]);
                    SwapBackAndForegroundColors();
                    continue;
                }
                Console.Write(_content[i]);
            }
            if (_sliderVisible)
            {
                _slider.Print();
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
