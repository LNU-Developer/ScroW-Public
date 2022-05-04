``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1645 (21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host] : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|       Method |     Mean |   Error |  StdDev |      Min |      Max | Ratio | RatioSD | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |---------:|--------:|--------:|---------:|---------:|------:|--------:|-----:|-------:|-------:|----------:|
|         Rest | 283.4 μs | 5.46 μs | 5.11 μs | 276.8 μs | 294.0 μs |  1.00 |    0.00 |    2 | 3.9063 | 1.9531 |     30 KB |
| HotChocolate | 211.0 μs | 1.31 μs | 1.22 μs | 208.8 μs | 213.3 μs |  0.74 |    0.01 |    1 | 4.1504 | 0.9766 |     31 KB |
|   GraphQLNet | 326.6 μs | 1.33 μs | 1.04 μs | 325.4 μs | 328.5 μs |  1.16 |    0.02 |    3 | 4.8828 | 0.9766 |     39 KB |
