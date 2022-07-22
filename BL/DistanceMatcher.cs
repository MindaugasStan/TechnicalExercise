using Entities;

namespace BL
{
        public class DistanceMatcher
        {
            private Point firstPoint;
            private Point secondPoint;

            public DistanceMatcher(Point firstPoint, Point secondPoint)
            {
                this.firstPoint = firstPoint;
                this.secondPoint = secondPoint;
            }

            public bool GoodNextPoint(Point thirdPoint)
            {
                var distance1 = PointDistance.Between(firstPoint, secondPoint);
                var distance2 = PointDistance.Between(secondPoint, thirdPoint);

                var rotateFirstDistance = distance1.Rotate();
                if (rotateFirstDistance == distance2)
                {
                    return true;
                }
                
                return false;
            }
        }

}
