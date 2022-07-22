using BL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTests
{
    [TestClass]
    public class DistanceMatcherTests
      {
        [TestMethod]
        public void CalculateDistanceBetweenTwoPoints()
        {
            var point1 = new Point(2, 2);
            var point2 = new Point(3, -1);
   
            var distance = PointDistance.Between(point1, point2);
            Assert.AreEqual(1, distance.X);
            Assert.AreEqual(-3, distance.Y);

        }
        [TestMethod]
        public void CalculateDistanceBetweenTwoPoints1()
        {
            var point1 = new Point(3, -1);
            var point2 = new Point(0, -2);

            var distance = PointDistance.Between(point1, point2);
            Assert.AreEqual(-3, distance.X);
            Assert.AreEqual(-1, distance.Y);

        }
        [TestMethod]
        public void CalculateDistanceBetweenTwoPoints2()
        {
            var point1 = new Point(0, -2);
            var point2 = new Point(-1, 1);

            var distance = PointDistance.Between(point1, point2);
            Assert.AreEqual(-1, distance.X);
            Assert.AreEqual(3, distance.Y);

        }

        [TestMethod]
        public void CalculateDistanceBetweenTwoPoints3()
        {
            var point1 = new Point(-1, 1);
            var point2 = new Point(2, 2);

            var distance = PointDistance.Between(point1, point2);
            Assert.AreEqual(3, distance.X);
            Assert.AreEqual(1, distance.Y);

        }
        [TestMethod]
        public void FindsNextGoodPoint()
        {
           
            var firstPoint = new Point(2, 2);
            var secondPoint = new Point(3, -1);
            var thirdPoint = new Point(0, -2);
            var distMatcher = new DistanceMatcher(firstPoint,secondPoint);
            var isGood = distMatcher.GoodNextPoint(thirdPoint);
            Assert.IsTrue(isGood);
        }

        [TestMethod]
        public void DoesNotFindNextGoodPoint()
        {

            var firstPoint = new Point(2, 2);
            var secondPoint = new Point(3, -1);
            var thirdPoint = new Point(0, -5);
            var distMatcher = new DistanceMatcher(firstPoint, secondPoint);
            var isGood = distMatcher.GoodNextPoint(thirdPoint);
            Assert.IsFalse(isGood);
        }

        [TestMethod]
        public void FindsLastGoodPoint()
        {

            var firstPoint = new Point(2, 2);
            var secondPoint = new Point(3, -1);
            var thirdPoint = new Point(0, -2);
            var fourPoint = new Point(-1, 1);
            var distMatcher = new DistanceMatcher(secondPoint, thirdPoint);
            var isGood = distMatcher.GoodNextPoint(fourPoint);
            Assert.IsTrue(isGood);
        }

        [TestMethod]
        public void DoesNotFindLastPoint()
        {

            var firstPoint = new Point(2, 2);
            var secondPoint = new Point(3, -1);
            var thirdPoint = new Point(0, -2);
            var fourPoint = new Point(-1, 3);
            var distMatcher = new DistanceMatcher(secondPoint, thirdPoint);
            var isGood = distMatcher.GoodNextPoint(firstPoint);
            Assert.IsFalse(isGood);
        }

    }
}
