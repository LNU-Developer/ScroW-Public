using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

namespace ScroW.Api.PerformanceTests.Benchmarks
{
    public class PostCreateToken : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async Task Rest()
        {
            var stringObj = @"
{
    ""organizationNumber"": ""1234567890"",
    ""socialSecurityNumber"": ""1234567890""
}
            ";
            var body = new StringContent(stringObj);
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PostAsync("/api/scro/createtoken/", body);
        }


        [Benchmark]
        public async Task HotChocolate()
        {
            var stringObj = @"
{
  ""query"": ""mutation($organizationNumber: String!, $socialSecurityNumber: String!) {\r\n  createToken(organizationNumber: $organizationNumber, socialSecurityNumber: $socialSecurityNumber) {\r\n    token\r\n    agreementText\r\n    agreementChangeDate\r\n  }\r\n}"",
  ""variables"": {
    ""organizationNumber"": ""1234567890"",
    ""socialSecurityNumber"": ""1234567890""
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
  ""query"": ""mutation($organizationNumber: String!, $socialSecurityNumber: String!) {\r\n  createToken(organizationNumber: $organizationNumber, socialSecurityNumber: $socialSecurityNumber) {\r\n    token\r\n    agreementText\r\n    agreementChangeDate\r\n  }\r\n}"",
  ""variables"": {
    ""organizationNumber"": ""1234567890"",
    ""socialSecurityNumber"": ""1234567890""
  }
}
            ";

            var body = new StringContent(stringObj);
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await client.PostAsync("/api/graphql/graphqlnet", body);
        }
    }
}