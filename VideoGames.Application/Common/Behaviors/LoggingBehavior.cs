using Serilog;
using MediatR;

namespace VideoGames.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("VideoGame Request: {Name} {@Request}", requestName, request);

            var response = await next();

            return response; 
        }
    }
}
