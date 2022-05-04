using BenchmarkDotNet.Running;
using ScroW.Api.PerformanceTests.Benchmarks;

namespace ScroW.Api.PerformanceTests
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<GetBasicInformation>();
            BenchmarkRunner.Run<GetBasicInformationOverFetching>();
            BenchmarkRunner.Run<GetBasicInformationUnderFetching>();
            BenchmarkRunner.Run<PostCreateToken>();
        }
    }
}