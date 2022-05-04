using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

namespace ScroW.Api.PerformanceTests.Benchmarks
{
    public class GetBasicInformationUnderFetching : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async Task Rest()
        {
            await client.GetAsync("/api/scro/basicinformation/" + "1234567890");
            await client.GetAsync("/api/scro/casestatus/" + "1234567890");
        }

        [Benchmark]
        public async Task HotChocolate()
        {
            var stringObj = @"
{
  ""query"": ""query ($organizationNumber: String!) {\r\n  basicInformation(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n    status {\r\n      code\r\n      text\r\n      date\r\n    }\r\n    financialPeriods {\r\n      start\r\n      end\r\n      isAudiorReportRequired\r\n    }\r\n    representatives {\r\n      firstName\r\n      name\r\n      socialSecurityNumber\r\n      otherIdentity\r\n      duties {\r\n        code\r\n        text\r\n      }\r\n    }\r\n  }\r\n  caseStatus(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n    retrieved\r\n    time\r\n    type\r\n    caseNumber\r\n    financialPeriod {\r\n      start\r\n      end\r\n    }\r\n  }\r\n}"",
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
  ""query"": ""query ($organizationNumber: String!) {\r\n  basicInformation(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n    status {\r\n      code\r\n      text\r\n      date\r\n    }\r\n    financialPeriods {\r\n      start\r\n      end\r\n      isAudiorReportRequired\r\n    }\r\n    representatives {\r\n      firstName\r\n      name\r\n      socialSecurityNumber\r\n      otherIdentity\r\n      duties {\r\n        code\r\n        text\r\n      }\r\n    }\r\n  }\r\n  caseStatus(organizationNumber: $organizationNumber) {\r\n    organizationNumber\r\n    name\r\n    retrieved\r\n    time\r\n    type\r\n    caseNumber\r\n    financialPeriod {\r\n      start\r\n      end\r\n    }\r\n  }\r\n}"",
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