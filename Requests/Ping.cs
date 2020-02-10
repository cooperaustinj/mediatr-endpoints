using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Requests
{
    public class Ping : IRequest<string>
    {
        public string Message { get; set; }
    }

    [ApiController]
    [Route("/req")]
    public class PingHandler : IRequestHandler<Ping, string>
    {
        [HttpPost("ping")]
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Pong: {request.Message}");
        }
    }
}


