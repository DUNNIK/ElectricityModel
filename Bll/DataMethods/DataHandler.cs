using System.Collections.Generic;
using System.Linq;
using Data;
using TinyCsvParser.Mapping;

namespace Bll.DataMethods
{
    public static class DataHandler
    {
        public static List<Point> UcGraphPoints(IEnumerable<CsvMappingResult<Experiment>> data)
        {
            return data.Select(t => new Point(double.Parse(t.Result.Ω), double.Parse(t.Result.Uc))).ToList();
        }
        public static List<Point> UlGraphPoints(IEnumerable<CsvMappingResult<Experiment>> data)
        {
            return data.Select(t => new Point(double.Parse(t.Result.Ω), double.Parse(t.Result.Ul))).ToList();
        }
        public static List<Point> UrGraphPoints(IEnumerable<CsvMappingResult<Experiment>> data)
        {
            return data.Select(t => new Point(double.Parse(t.Result.Ω), double.Parse(t.Result.Ur))).ToList();
        }
        
    }
}