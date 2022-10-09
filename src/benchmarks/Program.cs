using DotNetPerf.BenchmarkHelpers;

namespace DotNetPerf.Benchmarks
{
    internal static class Program
    {
        private static void Main(string[] args) =>
            DotNetPerfBenchmarkRunner.Run(typeof(Program), args, "../../../../../../results/details");
    }
}
