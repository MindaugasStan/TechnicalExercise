using Entities;

namespace BL
{
    public class PointDistance
    {

        public PointDistance()
        {
        }

        public PointDistance(int x, int y)
        {
            X = x;

            Y = y;

        }

        public int X { get; set; }

        public int Y { get; set; }

        public static PointDistance Between(Point point1, Point point2)
        {
            var XDist = point2.XAxis - point1.XAxis;
            var YDist = point2.YAxis - point1.YAxis;
            return new PointDistance(XDist, YDist);
        }

        public PointDistance Rotate()
        {
            return new PointDistance(Y, -X);
        }

        public static bool operator ==(PointDistance a, PointDistance b)
        {
            return a.X == b.X && a.Y == b.Y;

        }
        public static bool operator !=(PointDistance a, PointDistance b)
        {
            return !(a == b);
        }
    }


}
