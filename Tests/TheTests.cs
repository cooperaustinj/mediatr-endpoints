using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatREndpoints;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Requests;
using Xunit;

namespace Tests
{
    public class TheTests
    {
        [Fact]
        public async Task Foo_Returns_CorrectResponse()
        {
            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                // Add TestServer
                webHost.UseTestServer();
                webHost.UseStartup<MediatREndpoints.Startup>();
            });
            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();

            var payload = JsonSerializer.Serialize(new Foo() { Message = "asdf" });
            var res = await client.PostAsync("/req/foo", new StringContent(payload, Encoding.UTF8, "application/json"));

            res.EnsureSuccessStatusCode();
            Assert.Equal("{\"message\":\"asdf\"}", await res.Content.ReadAsStringAsync());
        }
    }
}
