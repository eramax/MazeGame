using System;
using MazeClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeClientTests
{
    [TestClass]
    public class HelpersUnitTests
    {
        [TestMethod]
        //Testing that the ToPoint method is mapping the id to the coorect x ^ y in the matrix
        public void ToPointTest()
        {
            var point = Helpers.ToPoint(16, 10);
            var exected_x = 1;
            var exected_y = 6;

            Assert.AreEqual(exected_x, point.Item1);
            Assert.AreEqual(exected_y, point.Item2);
        }
    }
}
