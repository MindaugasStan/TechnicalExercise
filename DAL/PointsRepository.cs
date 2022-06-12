using Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PointsRepository : IPointsRepository
    {
        private PointSetList _pointList;
        private StreamReader _reader;
        private FilePaths _filePaths;
        private string _setNumber;

        public PointsRepository(IOptions<FilePaths> filePaths)
        {
            _filePaths = filePaths.Value;
            _reader = new StreamReader(_filePaths.DataFile);
        }
        public PointSet GetPointSet(string setNumber)
        {
            _setNumber = setNumber;
            PointSet result = GetPointSets().Find(x => x.PointSetID == _setNumber);
            return result;
        }

        private List<PointSet> GetPointSets()
        {
            return GetPointList().PointSet;
        }

        public void SaveCalculationOutput(List<Results> result)
        {
           
            string json =  JsonConvert.SerializeObject(result);
            string FileName = _setNumber + "_" + DateTime.Now.ToString("MMddyyy_Hmm") + ".json";
            File.WriteAllText(Path.Combine(_filePaths.SquareOutput, FileName), json);
        }

        private PointSetList GetPointList()
        {
            if (_pointList == null)
            {
                string jsonString = _reader.ReadToEnd();
                _pointList = JsonConvert.DeserializeObject<PointSetList>(jsonString);
            }

            return _pointList;
        }

        public List<Results> FormatResultList(List<Square> squareList)
        {
            List<Result> result = new List<Result>();
            result.Add(new Result()
            {
                PointSetID = _setNumber,
                CalculationDateTime = DateTime.Now.ToString("MMddyyy_Hmm").ToString(),
                Square = squareList
            });

            List<Results> resultList = new List<Results>();

            resultList.Add(new Results()
            {
                Result = result,
            });

            return resultList;
        }
    }
}
