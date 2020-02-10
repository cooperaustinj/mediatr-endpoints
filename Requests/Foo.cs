using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Requests
{
    public class Foo : IRequest<object>
    {
        public string Message { get; set; }
    }

    [ApiController]
    [Route("/req")]
    public class FooHandler : IRequestHandler<Foo, object>
    {
        [HttpPost("foo")]
        public Task<object> Handle(Foo request, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(new { Message = request.Message });
        }
    }
}


