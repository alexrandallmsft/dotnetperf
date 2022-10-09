using BenchmarkDotNet.Attributes;

using DotNetPerf.BenchmarkHelpers;

namespace DotNetPerf.Benchmarks.System
{
    public class System_String_Equals
    {
        private const int TotalItemsToTest = 30;

        [Benchmark(Description = "s1 == s2")]
        public bool Sign()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = _values1[i] == _values2[i];
            }

            return result;
        }

        [Benchmark(Description = "s1.Equals(s2)")]
        public bool InstEquals()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = _values1[i].Equals(_values2[i]);
            }

            return result;
        }


        [Benchmark(Description = "s1.Equals(s2, StringComparison.Ordinal)")]
        public bool InstEqualsComp()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = _values1[i].Equals(_values2[i], StringComparison.Ordinal);
            }

            return result;
        }

        [Benchmark(Description = "s1.AsSpan().SequenceEqual(s2.AsSpan())")]
        public bool SpanSeqEquals()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = _values1[i].AsSpan().SequenceEqual(_values2[i].AsSpan());
            }

            return result;
        }

        [Benchmark(Description = "string.Equals(s1,s2)")]
        public bool StaticEquals()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = string.Equals(_values1[i], _values2[i]);
            }

            return result;
        }

        [Benchmark(Description = "string.Equals(s1,s2,StringComparison.Ordinal)")]
        public bool StaticEqualsComp()
        {
            bool result = false;
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                result = string.Equals(_values1[i], _values2[i], StringComparison.Ordinal);
            }

            return result;
        }

        private string[] _values1;
        private string[] _values2;

        [GlobalSetup]
        public void Setup()
        {
            const int stringLengthToTest = 30;
            _values1 = ValuesGenerator.ArrayOfStrings(TotalItemsToTest, stringLengthToTest, stringLengthToTest);
            string[] tempValues = ValuesGenerator.ArrayOfStrings(TotalItemsToTest, stringLengthToTest, stringLengthToTest);
            _values2 = new string[TotalItemsToTest];
            for (int i = 0; i < TotalItemsToTest; i++)
            {
                _values2[i] =
                    ValuesGenerator.Boolean()
                    ? tempValues[i]
                    : new string(_values1[i]);
            }
        }
    }
}
