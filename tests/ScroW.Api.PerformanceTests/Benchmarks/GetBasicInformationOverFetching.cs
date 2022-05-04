using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

namespace ScroW.Api.PerformanceTests.Benchmarks
{
    public class GetBasicInformationOverFetching : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async Task Rest()
        {
            await client.GetAsync("/api/scro/basicinformation/" + "1234567890");
        }

        [Benchmark]
        public async Task HotChocolate()
        {
            var stringObj = @"
{
  ""query"": ""query ($organizationNumber: String!) {\r\n  basicInformation(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n  }\r\n}"",
  ""variables"": {
    ""organizationNumber"": ""1234567890""
  }
}
            ";

            var body = new StringContent(stringObj);
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await client.PostAsync("/graphql", body);
        }

        [Benchmark]
        public async Task GraphQLNet()
        {
            var stringObj = @"
{
  ""query"": ""query ($organizationNumber: String!) {\r\n  basicInformation(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n  }\r\n}"",
  ""variables"": {
    ""organizationNumber"": ""1234567890""
  }
}
            ";

            var body = new StringContent(stringObj);
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await client.PostAsync("/api/graphql/graphqlnet", body);
        }
    }
}