using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class MiddlewareTests
    {
        [Fact]
        public async Task ShouldReturnNotFoundForRequest()
        {
            var host = new HostBuilder();
            host.ConfigureWebHost((webBuilder) =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {

                    })
                    .Configure(app =>
                    {

                    });
            });

            await host.StartAsync();
        }
    }
}