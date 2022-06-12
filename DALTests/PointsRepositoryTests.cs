using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Microsoft.Extensions.Options;
using Entities;
using System.Collections.Generic;
using System;
using System.IO;

namespace DALTests
{
    [TestClass]
    public class PointsRepositoryTests
    {
        private PointsRepository _pointsRepository;
        private IOptions<FilePaths> _options;

        public PointsRepositoryTests()
        {
             _options = Options.Create(new FilePaths()
            {
                DataFile = "C:\\Users\\MindaugasStanionis\\source\\repos\\Exercise\\API\\PointSets.json",
                SquareOutput = "D:\\"
            });
            _pointsRepository = new PointsRepository(_options);
        }
        [TestMethod]
        public void PointSetIsNullIfWrongSetID()
        {
            var pointSet = _pointsRepository.GetPointSet("WrongTestID");

            Assert.IsNull(pointSet);
            
        }
        [TestMethod]
        public void PointSetIsNotNullIfCorrectSetID()
        {
            var pointSet = _pointsRepository.GetPointSet("PS1");

            Assert.IsNotNull(pointSet);

        }
        
        [TestMethod]
        public void PointSetTypeIsCorrect()
        {
            var pointSet = _pointsRepository.GetPointSet("PS1");

            Assert.IsInstanceOfType(pointSet, typeof(PointSet));
        }

    }
}
