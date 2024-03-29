﻿using System;

namespace MazeClient
{
    public class Maze
    {
        // Maze size
        int Size { get; set; }
        // Maze Rooms
        char[,] Rooms { get; set; }
        // Maze Enterance
        int Enterance { get; set; }

        // Setup a maze with its size and its enterance
        public Maze(int size, int enterance)
        {
            Size = size;
            Rooms = new char[size,size];
            Enterance = enterance;
            SetRoom(enterance, 'A');
        }
        // Set room status with a character
        public void SetRoom(int id, char ch)
        {
            if (id >= Size * Size) return;
            var point = Helpers.ToPoint(id, Size);
            Rooms[point.Item1, point.Item2] = ch;
        }

        // Print the Maze and highlight the currect room
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

