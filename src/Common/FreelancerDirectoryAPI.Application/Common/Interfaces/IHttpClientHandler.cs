using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;

        Task<ServiceResult<TResult>> GenericRequestWithAuthorization<TRequest, TResult>(string clientApi, string url,string token,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null, string authorizationHeaderName = "Authorization")
            where TResult : class where TRequest : class;
    }
}