``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1645 (21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host] : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|       Method |     Mean |   Error |  StdDev |      Min |      Max | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |---------:|--------:|--------:|---------:|---------:|------:|--------:|-----:|-------:|-------:|----------:|
|         Rest | 277.7 μs | 4.86 μs | 4.55 μs | 268.2 μs | 283.3 μs |  1.00 |    0.00 |    2 | 3.4180 | 1.4648 |     28 KB |
| HotChocolate | 210.0 μs | 1.38 μs | 1.29 μs | 208.0 μs | 211.9 μs |  0.76 |    0.01 |    1 | 3.1738 | 0.7324 |     25 KB |
|   GraphQLNet | 309.6 μs | 3.34 μs | 3.12 μs | 305.6 μs | 314.3 μs |  1.12 |    0.02 |    3 | 4.3945 | 0.9766 |     37 KB |
