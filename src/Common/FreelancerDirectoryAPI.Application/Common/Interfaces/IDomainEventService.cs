using System.Threading.Tasks;
using FreelancerDirectoryAPI.Domain.Common;

namespace FreelancerDirectoryAPI.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
