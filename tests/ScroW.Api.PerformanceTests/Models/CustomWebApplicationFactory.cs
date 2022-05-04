using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace ScroW.Api.PerformanceTests.Models
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
               .ConfigureServices(services =>
               {
                   var mockMediator = new Mock<IMediator>();
                   services.AddSingleton(mockMediator);
                   services.AddSingleton(mockMediator.Object);
               });

            base.ConfigureWebHost(builder);
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());
            return base.CreateHost(builder);
        }
    }
}
