using System;
using System.Drawing;

namespace FileManager
{
    static class ConsoleGraphics
    {
        public static void DrawLine(
            int point1_x,
            int point1_y,
            int point2_x,
            int point2_y,
            ConsoleColor color = ConsoleColor.White)
        {
            var temp = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.SetCursorPosition(point1_x, point1_y);
            Console.Write(' ');
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
                Console.Write(' ');
            } while ((point1_x, point1_y) != (point2_x, point2_y));

            Console.BackgroundColor = temp;
        }

        public static void DrawLine(
            Point startPoint,
            Point destPoint,
            ConsoleColor color = ConsoleColor.White)
        {
            DrawLine(
                startPoint.X, 
                startPoint.Y, 
                destPoint.X, 
                destPoint.Y,  
                color);
        }

        public static void DrawRectangle(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor borderColor = ConsoleColor.White)
        {
            DrawRectangle(
                new Point(x, y), 
                new Size(width, height), 
                borderColor);
        }

        public static void DrawRectangle(
            Point startPoint,
            Size size,
            ConsoleColor borderColor = ConsoleColor.White)
        {
            var temp = Console.BackgroundColor;
            Console.BackgroundColor = borderColor;

            Point point_2 = new Point(startPoint.X + size.Width, startPoint.Y);
            Point point_3 = new Point(startPoint.X, startPoint.Y + size.Height);
            Point point_4 = new Point(startPoint.X + size.Width, startPoint.Y + size.Height);

            DrawLine(startPoint, point_2, borderColor);
            DrawLine(startPoint, point_3, borderColor);
            DrawLine(point_2, point_4, borderColor);
            DrawLine(point_3, point_4, borderColor);

            Console.BackgroundColor = temp;
        }

        public static void FillRectangle(
            int x,
            int y,
            int width,
            int height,
            ConsoleColor color)
        {
            FillRectangle(
                new Point(x, y), 
                new Size(width, height), 
                color);
        }

        public static void FillRectangle(
            Point startPosition, 
            Size size, 
            ConsoleColor color)
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
            ConsoleColor color = ConsoleColor.White)
        {
            (int, int) tempPosition = Console.GetCursorPosition();
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.SetCursorPosition(tempPosition.Item1, tempPosition.Item2);
            Console.ForegroundColor = ConsoleColor.White;
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
                    color);
                DrawSymbol(points[i], pointSym, color);
                DrawSymbol(points[i+1], pointSym, color);
            }
        }
    }
}
