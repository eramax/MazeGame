using MazeClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace MazeClientTests
{
    [TestClass]
    public class GameUnitTests
    {
        GameClient game { get; set; }
        public GameUnitTests()
        {
            var MazeSize = 10;
            var Enterance = 15;
            IKernel kernal = new StandardKernel(new IntegrationModule());
            game = new GameClient(kernal.Get<IMazeIntegration>());
            game.MazeService.BuildMaze(MazeSize);
            game.VisitedMaze = new Maze(MazeSize, Enterance);
            game.ResetAllowedDirections();
            game.PlayerScore = 10;
            game.CurrentRoom = 5;
        }


        [TestMethod]
        //Testing Moving to the east
        public void MoveEastTest()
        {
            game.Move(5, 'E');
            var expected_newRoom = 6;
            Assert.AreEqual(expected_newRoom, game.CurrentRoom);
        }

        [TestMethod]
        //Testing Moving to the west
        public void MoveWestTest()
        {
            game.Move(5, 'W');
            var expected_newRoom = 4;
            Assert.AreEqual(expected_newRoom, game.CurrentRoom);
        }

        [TestMethod]
        //Testing Moving to the north
        public void MoveNorthTest()
        {
            game.Move(5, 'N');
            var expected_newRoom = 5;
            Assert.AreEqual(expected_newRoom, game.CurrentRoom);
        }

        [TestMethod]
        //Testing Moving to the south
        public void MoveSouthTest()
        {
            game.Move(5, 'S');
            var expected_newRoom = 15;
            Assert.AreEqual(expected_newRoom, game.CurrentRoom);
        }

        [TestMethod]
        //Testing Moving to a trap point
        public void HitTrapTest()
        {
            var oldScore = game.PlayerScore;
            game.Move(5, 'W');
            var expected_newScore = game.PlayerScore;
            Assert.AreEqual(expected_newScore , oldScore - 1);
        }

        [TestMethod]
        //Testing Moving to the treasure point
        public void HitTreasureTest()
        {
            game.Move(11, 'S');
            var expected_wom = true;
            Assert.AreEqual(expected_wom, game.Won);
        }

        [TestMethod]
        //Testing steps count are counting
        public void StepsCountTest()
        {
            var oldSteps = game.PlayerSteps;
            MoveEastTest();
            Assert.IsTrue(game.PlayerSteps == oldSteps + 1);
        }


        [TestMethod]
        //Testing to loos all the score
        public void LoosingAllScoreTest()
        {
            while (game.PlayerScore > 0)
            {
                HitTrapTest();
            }
            Assert.AreEqual(game.PlayerScore, 0);
        }
    }
}