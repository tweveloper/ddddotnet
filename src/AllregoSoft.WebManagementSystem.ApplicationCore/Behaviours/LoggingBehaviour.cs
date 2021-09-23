using AllregoSoft.WebManagementSystem.ApplicationCore.Extensions;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var userId = _identityService.GetUserId();

            _logger.LogInformation("----- Handling command {CommandName} {@UserId} ({@Command})", request.GetGenericTypeName(), userId, request);
            var response = await next();
            _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", request.GetGenericTypeName(), response);

            return response;
        }
    }
}
