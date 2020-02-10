using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Requests
{
    public class Ding : IRequest<string>
    {

    }

    [ApiController]
    [Route("/req")]
    public class DingHandler : IRequestHandler<Ding, string>
    {
        private readonly IMediator _m;

        public DingHandler(IMediator m)
        {
            _m = m;
        }

        [HttpPost("ding")]
        public Task<string> Handle(Ding request, CancellationToken cancellationToken)
        {
            return _m.Send(new Ping() { Message = "Ding" });
        }
    }
}