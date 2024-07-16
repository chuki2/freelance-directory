using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Domain.Persistence;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;
        private readonly ApplicationDbContext _context;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService, ApplicationDbContext context)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
            _context = context;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;
            string userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);

                _logger.LogInformation("FreelancerDirectoryAPI User Request: {Name} {@UserId} {@UserName} {@Request}",
                                        requestName, userId, userName, request);
            }

       

            _logger.LogInformation("FreelancerDirectoryAPI Request: {Name} {@Request}",
                                        requestName, request);



        }
    }
}
