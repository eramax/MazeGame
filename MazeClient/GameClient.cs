using System;
using System.Collections.Generic;

namespace MazeClient
{
    public class GameClient
    {
        public IMazeIntegration MazeService { get; set; }
        public int PlayerScore { get; set; }
        public int PlayerSteps { get; set; }
        public int Enterance { get; set; }
        public Maze VisitedMaze { get; set; }
        public int CurrentRoom { get; set; }
        Dictionary<string, bool> AllowedDirections { get; set; }
        public bool Won { get; set; } = false;

        public GameClient(IMazeIntegration service)
        {
            MazeService = service;
        }
        public void Play()
        {
            //Reading the size
            Helpers.ConsoleReadInt("Enter Maze Size : ", out int MazeSize);
            PlayerScore = 10;
            MazeService.BuildMaze(MazeSize);
            Enterance = MazeService.GetEntranceRoom();
            VisitedMaze = new Maze(MazeSize, Enterance);
            ResetAllowedDirections();
            CurrentRoom = Enterance;
            VisitedMaze.ConsolePrint(CurrentRoom);
            while (AskToMove()) ;
        }
        public bool AskToMove()
        {
            PrintInfo();

            string question = "Please Enter ";
            if (AllowedDirections["N"]) question += " [N] for North,";
            if (AllowedDirections["S"]) question += " [S] for South,";
            if (AllowedDirections["W"]) question += " [W] for West,";
            if (AllowedDirections["E"]) question += " [E] for East,";
            question += " [X] for Exit : ";

            Helpers.ConsoleReadChar(question, out var dir);
            if (dir == 'X' || dir == 'x') return false;
            if(AllowedDirections.TryGetValue(dir.ToString().ToUpper(),out var allowed) && allowed)
            {
                Move(CurrentRoom, dir);
                VisitedMaze.ConsolePrint(CurrentRoom);
                if (Won)
                {
                    Console.WriteLine("Conguratulations you found the Treasure.");
                    return false;
                }
                if (PlayerScore <= 0)
                {
                    Console.WriteLine("Your score is 0, Game Over.");
                    return false;
                }
            }else Console.WriteLine("Wrong Input");

            return true;
        }
        public void PrintInfo()
        {
            Console.WriteLine("SCORE : {0}, STEPS : {1}", PlayerScore, PlayerSteps);
        }
        public void Move(int id, char direction)
        {
            string dir = direction.ToString().ToUpper();
            var RoomId = MazeService.GetRoom(id, direction);
            // Null is an edge
            if (RoomId == null)
            {
                DisallowDirection(dir);
                return;
            }
            CurrentRoom = RoomId.Value;
            ResetAllowedDirections();
            var RoomDesc = MazeService.GetDescription(CurrentRoom);
            var isTrap = MazeService.CausesInjury(CurrentRoom);
            var isTreasure = MazeService.HasTreasure(CurrentRoom);

            PlayerSteps++;

            Console.WriteLine("[Room Description: {0} ]", RoomDesc);


            if (isTrap) { 
                VisitedMaze.SetRoom(CurrentRoom, 'O');
                Console.WriteLine("You trapped and your score has been decreased by one.");
                PlayerScore--;
            }else if(isTreasure)
            {
                VisitedMaze.SetRoom(CurrentRoom, '€');
                Won = true;
            }
            else if(CurrentRoom != Enterance)
                VisitedMaze.SetRoom(CurrentRoom, 'X');

        }
        public void ResetAllowedDirections()
        {
            AllowedDirections = new Dictionary<string, bool>();
            AllowedDirections.Add("N", true);
            AllowedDirections.Add("S", true);
            AllowedDirections.Add("W", true);
            AllowedDirections.Add("E", true);
        }
        public void DisallowDirection(string dir)
        {
            AllowedDirections[dir] = false;
        }
    }
}

