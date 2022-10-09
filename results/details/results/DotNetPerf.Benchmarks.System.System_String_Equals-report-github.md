``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.521)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  Job-KBZLSC : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2

Platform=X64  PowerPlanMode=00000000-0000-0000-0000-000000000000  Server=True  
IterationTime=250.0000 ms  MaxIterationCount=20  MinIterationCount=15  
WarmupCount=1  

```
|                                        Method |     Mean |   Error |  StdDev | Code Size | Allocated |
|---------------------------------------------- |---------:|--------:|--------:|----------:|----------:|
|                                    &#39;s1 == s2&#39; | 134.5 ns | 2.41 ns | 2.26 ns |     453 B |         - |
|                                 s1.Equals(s2) | 131.4 ns | 2.64 ns | 2.93 ns |     455 B |         - |
|     &#39;s1.Equals(s2, StringComparison.Ordinal)&#39; | 172.9 ns | 3.25 ns | 3.04 ns |     475 B |         - |
|        s1.AsSpan().SequenceEqual(s2.AsSpan()) | 152.4 ns | 3.09 ns | 3.56 ns |     460 B |         - |
|                          string.Equals(s1,s2) | 126.7 ns | 2.52 ns | 2.80 ns |     453 B |         - |
| string.Equals(s1,s2,StringComparison.Ordinal) | 165.7 ns | 3.25 ns | 3.48 ns |     481 B |         - |
