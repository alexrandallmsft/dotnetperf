using BenchmarkDotNet.Attributes;

using Microsoft.Azure.Cosmos;

namespace Benchmarks.Microsoft.Azure.Cosmos
{
    public class Microsoft_Azure_Cosmos_PartitionKey_Hardcoded
    {
        [Benchmark]
        public PartitionKey Field()
        {
            return _partitionKey;
        }

        [Benchmark]
        public PartitionKey NewFromConst()
        {
            return new(NumberOne);
        }

        private PartitionKey _partitionKey;
        private const double NumberOne = 1;

        [GlobalSetup]
        public void Init()
        {
            _partitionKey = new PartitionKey(NumberOne);
        }
    }
}
