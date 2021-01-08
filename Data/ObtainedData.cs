using System.Collections.Generic;
using TinyCsvParser.Mapping;

namespace Data
{
    public static class ObtainedData
    {
        public static List<CsvMappingResult<Experiment>> FirstFileData { get; set; }
        public static List<CsvMappingResult<Experiment>> SecondFileData{ get; set; }
        
    }
}