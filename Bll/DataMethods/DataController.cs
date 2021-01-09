using System.Collections.Generic;
using BLL.Exceptions;
using Data;
using TinyCsvParser.Mapping;

namespace Bll.DataMethods
{
    public static class DataController
    {
        public static void AddFirstData(List<CsvMappingResult<Experiment>> data)
        {
            ObtainedData.FirstFileData = data;
        }
        public static void AddSecondData(List<CsvMappingResult<Experiment>> data)
        {
            ObtainedData.SecondFileData = data;
        }
        

        public static List<CsvMappingResult<Experiment>> GetFirstData()
        {
            if (ObtainedData.FirstFileData == null) throw new DataAccessException();
            return ObtainedData.FirstFileData;
        }
        public static List<CsvMappingResult<Experiment>> GetSecondData()
        {
            if (ObtainedData.SecondFileData == null) throw new DataAccessException();
            return ObtainedData.SecondFileData;
        }
    }
}