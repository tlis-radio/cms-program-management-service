using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Dtos;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

public interface IBroadcastRepository : IGenericRepository<Broadcast>
{
    Task<PaginationDto<Broadcast>> PaginationAsync(int limit, int pageNumber);
}