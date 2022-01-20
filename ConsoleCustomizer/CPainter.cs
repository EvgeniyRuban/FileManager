using System;
using System.Drawing;
using ConsoleCustomizer.Source;

namespace ConsoleCustomizer
{
    public static class CPainter
    {
        public static void DrawLine(
            int point1_x,
            int point1_y,
            int point2_x,
            int point2_y,
            char sym = '#',
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            ConsoleColor tempBackgrounColor = Console.BackgroundColor;
            ConsoleColor tempForegroundColor = Console.ForegroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.SetCursorPosition(point1_x, point1_y);
            Console.Write(sym);
            do
            {
                if (point1_x < point2_x)
                {
                    point1_x++;
                }
                else if (point1_x > point2_x)
                {
                    point1_x--;
                }
                if (point1_y < point2_y)
                {
                    point1_y++;
                }
                else if (point1_y > point2_y)
                {
                    point1_y--;
                }
                Console.SetCursorPosition(point1_x, point1_y);
                Console.Write(sym);
            } while ((point1_x, point1_y) != (point2_x, point2_y));


            Console.BackgroundColor = tempBackgrounColor;
            Console.ForegroundColor = tempForegroundColor;
        }

        public static void DrawLine(
            Point startPoint,
            Point destPoint,
            char sym = '#',
            ConsoleColor color = ConsoleColor.White)
        {
            DrawLine(
                startPoint.X, 
                startPoint.Y, 
                destPoint.X, 
                destPoint.Y, 
                sym, 
                color);
        }

        public static void DrawRectangle(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor borderColor = ConsoleColor.White,
            char borderLineSym = '#')
        {
            Console.ForegroundColor = borderColor;

            int x2 = x + width; 
            int y2 = y;
            int x3 = x; 
            int y3 = y + height;
            int x4 = x + width; 
            int y4 = y + height;

            DrawLine(x, y, x2, y2, borderLineSym, borderColor);
            DrawLine(x, y, x3, y3, borderLineSym, borderColor);
            DrawLine(x2, y2, x4, y4, borderLineSym, borderColor);
            DrawLine(x3, y3, x4, y4, borderLineSym, borderColor);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrawRectangle(
            Point startPoint,
            Size size,
            ConsoleColor borderColor = ConsoleColor.White,
            char borderLineSym = '#')
        {
            DrawRectangle(startPoint.X, startPoint.Y, size.Width, size.Height, borderColor, borderLineSym);
        }

        public static void FillRectangle(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor color = ConsoleColor.Black)
        {
            FillRectangle(
                new Point(x, y), 
                new Size(width, height), 
                color);
        }

        public static void FillRectangle(
            Point startPosition, 
            Size size,
            ConsoleColor color = ConsoleColor.Black)
        {
            int rectHeight = startPosition.Y + size.Height;
            int rectWidth = startPosition.X + size.Width;
            Console.BackgroundColor = color;

            for (int i = startPosition.Y; i < rectHeight; i++)
            {
                for (int j = startPosition.X; j < rectWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Prints a character at the specified coordinates and returns carriage to its original position
        /// </summary>
        public static void DrawSymbol(
            int x, 
            int y, 
            char sym, 
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.White)
        {
            (int, int) tempPosition = Console.GetCursorPosition();
            ConsoleColor tempBackgrounColor = Console.BackgroundColor;
            ConsoleColor tempForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.SetCursorPosition(tempPosition.Item1, tempPosition.Item2);

            Console.BackgroundColor = tempBackgrounColor;
            Console.ForegroundColor = tempForegroundColor;
        }

        /// <summary>
        /// Prints a character at the specified coordinates and returns carriage to its original position
        /// </summary>
        public static void DrawSymbol(
            Point point, 
            char sym, 
            ConsoleColor color = ConsoleColor.White) => DrawSymbol(point.X, point.Y, sym, color); 

        public static void DrawLinkedPoints(
            Point[] points, 
            char lineSym = '*', 
            char pointSym = '0', 
            ConsoleColor color = ConsoleColor.White)
        {
            if(points == null)
            {
                throw new ArgumentNullException($"{points}");
            }
            else if(points.Length == 1)
            {
                DrawSymbol(points[0], pointSym);
            }

            for(int i = 0; i < points.Length -1; i++)
            {
                DrawLine(
                    points[i].X,
                    points[i].Y,
                    points[i + 1].X,
                    points[i + 1].Y,
                    lineSym,
                    color);
                DrawSymbol(points[i], pointSym, color);
                DrawSymbol(points[i+1], pointSym, color);
            }
        }

        public static void DrawOnceLineFrame(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            int x2 = x + width + 1;
            int y2 = y;
            int x3 = x;
            int y3 = y + height + 1;
            int x4 = x + width + 1;
            int y4 = y + height + 1;

            DrawLine(x, y, x2, y2, OnceLineFrame.HorizontalLine, backgroundColor, foregroundColor);
            DrawLine(x, y, x3, y3, OnceLineFrame.VerticalLine, backgroundColor, foregroundColor);
            DrawLine(x2, y2, x4, y4, OnceLineFrame.VerticalLine, backgroundColor, foregroundColor);
            DrawLine(x3, y3, x4, y4, OnceLineFrame.HorizontalLine, backgroundColor, foregroundColor);
            DrawSymbol(x, y, OnceLineFrame.UpperLeftCorner, foregroundColor, backgroundColor);
            DrawSymbol(x2, y2, OnceLineFrame.UpperRightCorner, foregroundColor, backgroundColor);
            DrawSymbol(x3, y3, OnceLineFrame.DownLeftCorner, foregroundColor, backgroundColor);
            DrawSymbol(x4, y4, OnceLineFrame.DownRightCorner, foregroundColor, backgroundColor);
        }
        public static void DrawOnceLineFrame(
            Point point,
            Size size,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor foregroundColor = ConsoleColor.White)
            => DrawDoubleLineFrame(point.X, point.Y, size.Width, size.Height, backgroundColor, foregroundColor);

        public static void DrawDoubleLineFrame(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            int x2 = x + width;
            int y2 = y;
            int x3 = x;
            int y3 = y + height;
            int x4 = x + width;
            int y4 = y + height;

            DrawLine(x, y, x2, y2, DoubleLineFrame.HorizontalLine, backgroundColor, foregroundColor);
            DrawLine(x, y, x3, y3, DoubleLineFrame.VerticalLine, backgroundColor, foregroundColor);
            DrawLine(x2, y2, x4, y4, DoubleLineFrame.VerticalLine, backgroundColor, foregroundColor);
            DrawLine(x3, y3, x4, y4, DoubleLineFrame.HorizontalLine, backgroundColor, foregroundColor);
            DrawSymbol(x, y, DoubleLineFrame.UpperLeftCorner, foregroundColor, backgroundColor);
            DrawSymbol(x2, y2, DoubleLineFrame.UpperRightCorner, foregroundColor, backgroundColor);
            DrawSymbol(x3, y3, DoubleLineFrame.DownLeftCorner, foregroundColor, backgroundColor);
            DrawSymbol(x4, y4, DoubleLineFrame.DownRightCorner, foregroundColor, backgroundColor);
        }
        public static void DrawDoubleLineFrame(
            Point point, 
            Size size, 
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor foregroundColor = ConsoleColor.White) 
            => DrawDoubleLineFrame(point.X, point.Y, size.Width, size.Height, backgroundColor, foregroundColor);
    }
}
