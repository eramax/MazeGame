using System;

namespace MazeClient
{
    public class Maze
    {
        public int Size { get; set; }

        public IMazeIntegration MazeIntegration { get; set; }
        char[,] Rooms;
        public int Enterance { get; set; }
        public Maze(int size, int enterance)
        {
            Size = size;
            Rooms = new char[size,size];
            Enterance = enterance;
            SetRoom(enterance, 'A');
        }
        public void SetRoom(int id, char ch)
        {
            if (id >= Size * Size) return;
            var point = Helpers.ToPoint(id, Size);
            Rooms[point.Item1, point.Item2] = ch;
        }

        public void ConsolePrint(int current)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0;j<Size;j++)
                {
                    var room = Rooms[i, j];
                    var roomId = i * Size + j;
                    if (roomId == current) {
                        if (roomId == Enterance) { Helpers.ConsoleWrite("$", 2, ConsoleColor.DarkMagenta); continue; }

                        switch (room)
                        {
                            case 'A': Helpers.ConsoleWrite("$", 2, ConsoleColor.DarkMagenta); break;
                            case 'O': Helpers.ConsoleWrite("$", 2, ConsoleColor.DarkRed); break;
                            case 'X': Helpers.ConsoleWrite("$", 2, ConsoleColor.DarkMagenta); break;
                            case '€': Helpers.ConsoleWrite("$", 2, ConsoleColor.DarkBlue); break;

                        }
                    }
                    else {
                        switch (room)
                        {
                            case 'A': Helpers.ConsoleWrite(room.ToString(), 2, ConsoleColor.DarkCyan); break;
                            case 'O': Helpers.ConsoleWrite(room.ToString(), 2, ConsoleColor.DarkRed); break;
                            case 'X': Helpers.ConsoleWrite(room.ToString(), 2, ConsoleColor.DarkGreen); break;
                            case '€': Helpers.ConsoleWrite(room.ToString(), 2, ConsoleColor.DarkBlue); break;
                            default:  Helpers.ConsoleWrite(".", 2, ConsoleColor.DarkGreen); break;
                        }
                    }
                }
                Console.Write('\n');
            }
            Console.ResetColor();
        }

       
    }
}

