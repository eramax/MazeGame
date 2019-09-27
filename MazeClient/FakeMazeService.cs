namespace MazeClient
{
    public class FakeMazeService : IMazeIntegration
    {
        int Size;
        public void BuildMaze(int size)
        {
            Size = size;
        }

        public bool CausesInjury(int roomId)
        {
            return roomId % 4 == 0;
        }

        public string GetDescription(int roomId)
        {
            return roomId +" desc";
        }

        public int GetEntranceRoom()
        {
            return Size * Size / 2;
        }

        public int? GetRoom(int roomId, char direction)
        {
            switch(direction)
            {
                case 'E':
                case 'e':
                    if ((int)(roomId % Size) + 1 < Size)
                        return roomId + 1;
                    else return null;

                case 'W':
                case 'w':
                    if ((int)(roomId % Size) - 1 >= 0)
                        return roomId - 1;
                    else return null;

                case 'S':
                case 's':
                    if (roomId + Size < Size*Size)
                        return roomId + Size;
                    else return null;

                case 'N':
                case 'n':
                    if (roomId - Size >= 0)
                        return roomId - Size;
                    else return null;
            }
            return roomId + 1;
        }

        public bool HasTreasure(int roomId)
        {
            return roomId == Size* 2 + 1;
        }
    }
}
