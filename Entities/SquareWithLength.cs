using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class MeasuredSquare
    {
        public Square Square { get; set; }
        public int Length { get; set; }
    }
}
