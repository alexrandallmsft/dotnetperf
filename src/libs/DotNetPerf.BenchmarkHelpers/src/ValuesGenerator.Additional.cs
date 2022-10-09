namespace DotNetPerf.BenchmarkHelpers
{
    public static partial class ValuesGenerator
    {
        public static bool Boolean() =>
            Random.Shared.Next(0, 1) == 0;
    }
}

