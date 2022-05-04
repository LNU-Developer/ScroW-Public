``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1645 (21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host] : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|       Method |     Mean |   Error |  StdDev |      Min |      Max | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |---------:|--------:|--------:|---------:|---------:|------:|--------:|-----:|-------:|-------:|----------:|
|         Rest | 289.4 μs | 3.29 μs | 3.07 μs | 285.5 μs | 294.2 μs |  1.00 |    0.00 |    2 | 3.4180 | 1.4648 |     28 KB |
| HotChocolate | 238.3 μs | 0.76 μs | 0.72 μs | 237.3 μs | 239.5 μs |  0.82 |    0.01 |    1 | 4.3945 | 0.9766 |     34 KB |
|   GraphQLNet | 429.7 μs | 1.08 μs | 0.90 μs | 428.5 μs | 431.3 μs |  1.48 |    0.02 |    3 | 6.8359 | 1.4648 |     52 KB |
