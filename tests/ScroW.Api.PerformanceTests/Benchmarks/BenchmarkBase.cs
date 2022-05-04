using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ScroW.Api.PerformanceTests.Models;
using ScroW.Application.Features.Information.Queries.BasicInformation;
using ScroW.Application.Features.Information.Queries.CaseStatus;
using ScroW.Application.Features.Token.Commands.CreateToken;

namespace ScroW.Api.PerformanceTests.Benchmarks
{
    [InProcess]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn]
    [Config(typeof(TestConfig))]
    public abstract class BenchmarkBase
    {
        public HttpClient client;
        public Mock<IMediator> mockMediator;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var factory = new CustomWebApplicationFactory<Startup>();
            client = factory.CreateClient();
            var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            mockMediator = scope.ServiceProvider.GetRequiredService<Mock<IMediator>>();

            var expectedBasicInformationResult = MockResponse.GetExpectedBasicInformationResponse();
            var expectedCaseStatusResponse = MockResponse.GetExpectedCaseStatusResponse();
            var expectedCreateTokenResponse = MockResponse.GetExpectedCreateTokenResponse();

            mockMediator.Setup(m => m.Send(It.IsAny<BasicInformationQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => expectedBasicInformationResult);

            mockMediator.Setup(m => m.Send(It.IsAny<CaseStatusQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => expectedCaseStatusResponse);

            mockMediator.Setup(m => m.Send(It.IsAny<CreateTokenCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => expectedCreateTokenResponse);
        }
    }
}
