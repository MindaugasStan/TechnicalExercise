using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Point
    {
        public Point()
        {

        }
        public Point(int x, int y)
        {
            XAxis = x;
            YAxis = y;
        }
        public string PointSetID { get; set; }
        public string PointCoordinateID { get; set; }
        public int XAxis { get; set; }
        public int YAxis { get; set; }
    }
}
