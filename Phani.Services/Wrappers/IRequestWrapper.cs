using MediatR;

namespace Phani.Services.Wrappers
{
    public class IRequestWrapper<T> : IRequest<Response<T>>
    {

    }

    public interface IHandleWrapper<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IRequestWrapper<TOut>
    {

    }
}
