using Entities;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SquareCalculator
    {
        private IPointsRepository _pointsRepository;
        public SquareCalculator(IPointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }

        public List<Square> SquareCalculatorFunc(string setID)
        {
            var pointset = _pointsRepository.GetPointSet(setID);
            if (pointset == null)
            {
                return null;
            }

            var result = CountSquares(setID, pointset);
            return result;

        }

        public List<Results> FormatResults(List<Square> result)
        {
            return _pointsRepository.FormatResultList(result);
        }

        private static List<Square> CountSquares(string setID, PointSet pointList)
        {
            List<MeasuredSquare> result = new List<MeasuredSquare>();
            List<double> distances = new List<double>();

            // Remove duplicates from List
            var pointSet = pointList.PointCoordinate.DistinctBy(x => new { x.XAxis, x.YAxis }).ToList();

            int length;

            for (int i = 0; i < pointSet.Count; i++)
            {
                var topLeft = pointSet[i];
                for (int j = i + 1; j < pointSet.Count; j++)
                {

                    var topRight = pointSet[j];

                    var distanceMatcher = new DistanceMatcher(topLeft, topRight);

                    for (int k = j + 1; k < pointSet.Count; k++)
                    {

                        var bottomRight = pointSet[k];
                        if (!distanceMatcher.GoodNextPoint(bottomRight))
                        {
                            continue;
                        }
                        for (int l = k + 1; l < pointSet.Count; l++)
                        {

                            var bottomLeft = pointSet[l];
                            var distanceMatcher1 = new DistanceMatcher(topRight, bottomRight);
                            if (distanceMatcher1.GoodNextPoint(bottomLeft))
                            {
                                length = topRight.XAxis - topLeft.XAxis;
                                result.Add(new MeasuredSquare()
                                {
                                    Square = new Square() { PointCoordinate = new() { topLeft, topRight, bottomRight, bottomLeft } },
                                    Length = length
                                });

                            }
                        }

                    }

                }
            }
            return result.OrderBy(x => x.Length)
                 .Select((x, index) =>
                 {
                     x.Square.SquareSeq = index + 1;
                     return x.Square;
                 })
                 .ToList();
        }

    }
}

