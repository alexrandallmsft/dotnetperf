``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.674)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  Job-DONVKF : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Platform=X64  PowerPlanMode=00000000-0000-0000-0000-000000000000  Server=True  
IterationTime=250.0000 ms  MaxIterationCount=20  MinIterationCount=15  
WarmupCount=1  

```
|   Method |       Mean |     Error |    StdDev |     Median |   Gen0 | Code Size | Allocated |
|--------- |-----------:|----------:|----------:|-----------:|-------:|----------:|----------:|
|      New | 52.1384 ns | 1.0704 ns | 0.8938 ns | 52.3355 ns | 0.0045 |     263 B |     160 B |
|  Default |  0.0540 ns | 0.0342 ns | 0.0394 ns |  0.0401 ns |      - |      14 B |         - |
|    Field |  3.5802 ns | 1.2516 ns | 1.4413 ns |  2.9263 ns |      - |      27 B |         - |
| FieldInt | 51.9301 ns | 2.0723 ns | 2.3033 ns | 51.4180 ns | 0.0046 |     263 B |     160 B |
