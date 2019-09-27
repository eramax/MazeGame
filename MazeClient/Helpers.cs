using System;

namespace MazeClient
{
    public static class Helpers
    {
        // Finding the correct x&y inside the maze with room id
        public static (int, int) ToPoint(int idx, int size)
        {
            int x = idx / size;
            int y = idx % size;
            return (x, y);
        }
        // Loops untill reading an int from the user
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
        // Loops untill reading an character from the user

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
        // writes a message within a specific space in console with a specified color
        public static void ConsoleWrite(string message, int padding, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message.PadLeft(padding));
            Console.ResetColor();

        }
    }
}
