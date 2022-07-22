using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using Entities;
using System.Collections.Generic;
using DAL;
using Moq;

namespace BLTests
{
    [TestClass]
    public class SquareCalculatorTests
    {
        private SquareCalculator _sut;
        private Mock<IPointsRepository> _pointsRepoMock = new Mock<IPointsRepository>();

        public SquareCalculatorTests()
        {
            _sut = new SquareCalculator(_pointsRepoMock.Object);
        }

        [TestMethod]
        public void CountSquaresCountsCorrectAmountOfSquares()
        {

            List<Point> points = new List<Point>()
            {
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "1",
                    XAxis = 0,
                    YAxis = 0,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "2",
                    XAxis = 0,
                    YAxis = 2,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "3",
                    XAxis = 2,
                    YAxis = 2,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "4",
                    XAxis = 2,
                    YAxis = 0,
                },
                
            };
            PointSet pointSet = new PointSet()
            {
                PointSetID = "PS1",
                PointCoordinate = points
            };

            _pointsRepoMock.Setup(x => x.GetPointSet("PS1")).Returns(pointSet);
            List<Square> squares = _sut.SquareCalculatorFunc("PS1");

            Assert.AreEqual(1,squares.Count);
           
        }

        [TestMethod]
        public void CountSquaresReturnsNotNull()
        {
            List<Point> points = new List<Point>()
            {
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "1",
                    XAxis = -1,
                    YAxis = 1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "2",
                    XAxis = 1,
                    YAxis = -1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "3",
                    XAxis = -1,
                    YAxis = -1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "4",
                    XAxis = 1,
                    YAxis = 1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "5",
                    XAxis = -1,
                    YAxis = 2,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "6",
                    XAxis = 1,
                    YAxis = 2,
                },
            };
            PointSet pointSet = new PointSet()
            {
                PointSetID = "PS1",
                PointCoordinate = points
            };

            _pointsRepoMock.Setup(x => x.GetPointSet("PS1")).Returns(pointSet);
            var squares = _sut.SquareCalculatorFunc("PS1");

            Assert.IsNotNull(squares);
        }
        [TestMethod]
        public void CountSquaresReturnsCorrectType()
        {
            List<Point> points = new List<Point>()
            {
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "1",
                    XAxis = -1,
                    YAxis = 1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "2",
                    XAxis = 1,
                    YAxis = -1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "3",
                    XAxis = -1,
                    YAxis = -1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "4",
                    XAxis = 1,
                    YAxis = 1,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "5",
                    XAxis = -1,
                    YAxis = 2,
                },
                new Point()
                {
                    PointSetID = "PS1",
                    PointCoordinateID = "6",
                    XAxis = 1,
                    YAxis = 2,
                },
            };
            PointSet pointSet = new PointSet()
            {
                PointSetID = "PS1",
                PointCoordinate = points
            };

            _pointsRepoMock.Setup(x => x.GetPointSet("PS1")).Returns(pointSet);
            var squares = _sut.SquareCalculatorFunc("PS1");

            Assert.IsInstanceOfType(squares, typeof(List<Square>));
        }
    }
}
