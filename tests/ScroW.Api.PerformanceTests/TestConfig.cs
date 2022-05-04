using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;

namespace ScroW.Api.PerformanceTests
{
    public class TestConfig : ManualConfig
    {
        public TestConfig()
        {
            AddColumn(RankColumn.Arabic);
            AddExporter(CsvMeasurementsExporter.Default);
            AddExporter(RPlotExporter.Default);
        }
    }
}
