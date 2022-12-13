``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.674)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  Job-JGQQFZ : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Platform=X64  PowerPlanMode=00000000-0000-0000-0000-000000000000  Server=True  
IterationTime=250.0000 ms  MaxIterationCount=20  MinIterationCount=15  
WarmupCount=1  

```
|       Method |      Mean |     Error |    StdDev | Code Size |   Gen0 | Allocated |
|------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|        Field |  1.820 ns | 0.0448 ns | 0.0398 ns |      27 B |      - |         - |
| NewFromConst | 44.474 ns | 0.6846 ns | 0.6069 ns |     271 B | 0.0046 |     160 B |
