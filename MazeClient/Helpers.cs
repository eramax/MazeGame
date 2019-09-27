using System;

namespace MazeClient
{
    public static class Helpers
    {
        public static (int, int) ToPoint(int idx, int size)
        {
            int x = idx / size;
            int y = idx % size;
            return (x, y);
        }
        public static bool ConsoleReadInt(string message, out int num)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (int.TryParse(input, out num))
            {
                return true;
            }
            else
            {
                return ConsoleReadInt(message, out num);
            }
        }

        public static bool ConsoleReadChar(string message, out char ch)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            if (char.TryParse(input, out ch))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Wrong Input");
                return ConsoleReadChar(message, out ch);
            }
        }
        public static void ConsoleWrite(string message, int padding, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message.PadLeft(padding));
            Console.ResetColor();

        }
    }
}
