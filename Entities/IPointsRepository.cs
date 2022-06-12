using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IPointsRepository
    {
        PointSet GetPointSet(string setID);
        void SaveCalculationOutput(List<Results> result);
        List<Results> FormatResultList(List<Square> squareList);
    }
}
