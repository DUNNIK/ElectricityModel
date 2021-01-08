using Data;
using TinyCsvParser.Mapping;

namespace Bll.Csv
{
    public class CsvPersonMapping : CsvMapping<Experiment>
    {
        public CsvPersonMapping()
            : base()
        {
            MapProperty(0, x => x.Number);
            MapProperty(1, x => x.F);
            MapProperty(2, x => x.Ω);
            MapProperty(3, x => x.Uc);
            MapProperty(4, x => x.Ul);
            MapProperty(5, x => x.Ur);
        }
    }
}