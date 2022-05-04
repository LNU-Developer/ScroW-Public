``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1645 (21H2)
Intel Core i7-5930K CPU 3.50GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host] : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|       Method |     Mean |   Error |  StdDev |      Min |      Max | Ratio | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |---------:|--------:|--------:|---------:|---------:|------:|-----:|-------:|-------:|----------:|
|         Rest | 547.6 μs | 9.63 μs | 8.54 μs | 536.5 μs | 562.0 μs |  1.00 |    3 | 6.8359 | 2.9297 |     54 KB |
| HotChocolate | 317.3 μs | 1.68 μs | 1.58 μs | 315.0 μs | 320.5 μs |  0.58 |    1 | 4.8828 | 1.4648 |     38 KB |
|   GraphQLNet | 527.2 μs | 3.11 μs | 2.90 μs | 523.0 μs | 532.9 μs |  0.96 |    2 | 7.8125 | 1.9531 |     61 KB |
