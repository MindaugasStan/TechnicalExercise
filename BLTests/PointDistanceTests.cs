using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTests
{

    [TestClass]
    public class PointDistanceTests
    {
        [TestMethod]
        public void RotatesStraightSquareLeftToTop()
        {
            var distance = new PointDistance(0,3);

            var newDist = distance.Rotate();

            Assert.AreEqual(3, newDist.X);
            Assert.AreEqual(0, newDist.Y);
        }

        [TestMethod]
        public void RotatesStraightSquareTopToRight()
        {
            var distance = new PointDistance(3, 0);

            var newDist = distance.Rotate();

            Assert.AreEqual(0, newDist.X);
            Assert.AreEqual(-3, newDist.Y);
        }
        [TestMethod]
        public void RotatesStraightSquareRightToBottom()
        {
            var distance = new PointDistance(0, -3);

            var newDist = distance.Rotate();

            Assert.AreEqual(-3, newDist.X);
            Assert.AreEqual(0, newDist.Y);
        }

        [TestMethod]
        public void RotatesStraightSquareBottomToLeft()
        {
            var distance = new PointDistance(-3, 0);

            var newDist = distance.Rotate();

            Assert.AreEqual(0, newDist.X);
            Assert.AreEqual(3, newDist.Y);
        }

        [TestMethod]
        public void RotatesLeftLeaningSquareLeftToTop()
        {
            var distance = new PointDistance(-1, 3);

            var newDist = distance.Rotate();

            Assert.AreEqual(3, newDist.X);
            Assert.AreEqual(1, newDist.Y);
        }

        [TestMethod]
        public void RotatesLeftLeaningSquareTopToRight()
        {
            var distance = new PointDistance(3, 1);

            var newDist = distance.Rotate();

            Assert.AreEqual(1, newDist.X);
            Assert.AreEqual(-3, newDist.Y);
        }
        [TestMethod]
        public void RotatesLeftLeaningSquareRightToBottom()
        {
            var distance = new PointDistance(1, -3);

            var newDist = distance.Rotate();

            Assert.AreEqual(-3, newDist.X);
            Assert.AreEqual(-1, newDist.Y);
        }

        [TestMethod]
        public void RotatesLeftLeaningSquareBottomToLeft()
        {
            var distance = new PointDistance(-3, -1);

            var newDist = distance.Rotate();

            Assert.AreEqual(-1, newDist.X);
            Assert.AreEqual(3, newDist.Y);
        }
    }


}
