using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Bll.Csv
{
    public static class CsvReader
    {
        public static List<CsvMappingResult<Experiment>> ReadCsv(string filePath)
        {
            var csvParserOptions = new CsvParserOptions(true, '\t');
            var csvMapper = new CsvPersonMapping();
            var csvParser = new CsvParser<Experiment>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromFile(filePath, Encoding.ASCII)
                .ToList();
            
            return result;
        }
    }
}