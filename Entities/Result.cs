using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Result
    {
        public string PointSetID { get; set; }
        public string CalculationDateTime { get; set; }
        public string NumberOfSquares => Square.Count.ToString();
        public List<Square> Square { get; set; }
    }
}
