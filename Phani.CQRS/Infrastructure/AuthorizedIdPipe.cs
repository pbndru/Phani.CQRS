using MediatR;
using Microsoft.AspNetCore.Http;
using Phani.Services;
using Phani.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Phani.CQRS.Infrastructure
{
    // Middleware
    public class AuthorizedIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext httpContext;

        public AuthorizedIdPipe(IHttpContextAccessor accessor) 
        {
            this.httpContext = accessor.HttpContext;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            if(request is BaseRequest authorizedRequest)
            {
                authorizedRequest.AuthorizedId = "phani";
            }

            var result = await next(); 

            if(result is Response<Vehicle> vehicleResponse)
            {
                vehicleResponse.Data.Name += " FOUND";
            }

            return result;
        }
    }
}
