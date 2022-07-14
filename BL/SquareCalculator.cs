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
            if(pointset == null)
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
                for (int j = 0; j < pointSet.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var topRight = pointSet[j];

                    if (topLeft.XAxis == topRight.XAxis && topLeft.YAxis == topRight.YAxis)
                    {
                        continue;
                    }

                        for (int k = 0; k < pointSet.Count; k++)
                        {
                            if (i == j || j == k || i == k)
                            {
                                continue;

                            }

                            var bottomRight = pointSet[k];
                        var firstDistance = distSquare(topLeft, topRight);
                        distances.Add(distSquare(topLeft, topRight));
                        distances.Add(distSquare(topLeft, bottomRight));
                        distances.Add(distSquare(topRight, bottomRight));
                            if (distances.All(x => x == firstDistance))
                            {
                                for (int l = 0; l < pointSet.Count; l++)
                                {
                                    if (i == j || j == k || k == l || i == l)
                                    {
                                        continue;
                                    }

                                    var bottomLeft = pointSet[l];
                                distances.Add(distSquare(bottomLeft, topLeft));
                                distances.Add(distSquare(bottomLeft, topRight));
                                distances.Add(distSquare(bottomLeft, bottomRight));
                                if (distances.All(x => x == firstDistance))
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
            }
            return result.OrderBy(x => x.Length)
                 .Select((x, index) => {
                     x.Square.SquareSeq = index + 1;
                     return x.Square;
                 })
                 .ToList();
        }

        private static double distSquare(Point p, Point q)
        {
            return Math.Sqrt(Math.Pow(p.XAxis - q.XAxis, 2) + Math.Pow(p.YAxis - q.YAxis, 2));
            
        }
        //private static bool isSquare(Point p1, Point p2, Point p3, Point p4)
        //{
        //    int d2 = distSquare(p1, p2); // from p1 to p2
        //    int d3 = distSquare(p1, p3); // from p1 to p3
        //    int d4 = distSquare(p1, p4); // from p1 to p4

        //    if (d2 == 0 || d3 == 0 || d4 == 0)
        //        return false;

        //    // If lengths if (p1, p2) and (p1, p3) are same, then
        //    // following conditions must met to form a square.
        //    // 1) Square of length of (p1, p4) is same as twice
        //    // the square of (p1, p2)
        //    // 2) Square of length of (p2, p3) is same
        //    // as twice the square of (p2, p4)
        //    if (d2 == d3 && 2 * d2 == d4
        //        && 2 * distSquare(p2, p4) == distSquare(p2, p3))
        //    {
        //        return true;
        //    }

        //    // The below two cases are similar to above case
        //    if (d3 == d4 && 2 * d3 == d2
        //        && 2 * distSquare(p3, p2) == distSquare(p3, p4))
        //    {
        //        return true;
        //    }
        //    if (d2 == d4 && 2 * d2 == d3
        //        && 2 * distSquare(p2, p3) == distSquare(p2, p4))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}

