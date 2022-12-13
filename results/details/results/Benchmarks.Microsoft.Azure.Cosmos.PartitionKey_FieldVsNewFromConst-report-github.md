``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.674)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  Job-YPRARH : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Platform=X64  PowerPlanMode=00000000-0000-0000-0000-000000000000  Server=True  
IterationTime=250.0000 ms  MaxIterationCount=20  MinIterationCount=15  
WarmupCount=1  

```
|       Method |      Mean |     Error |    StdDev | Code Size |   Gen0 | Allocated |
|------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|        Field |  1.986 ns | 0.0596 ns | 0.0558 ns |      27 B |      - |         - |
| NewFromConst | 46.097 ns | 0.2662 ns | 0.2079 ns |     271 B | 0.0045 |     160 B |
