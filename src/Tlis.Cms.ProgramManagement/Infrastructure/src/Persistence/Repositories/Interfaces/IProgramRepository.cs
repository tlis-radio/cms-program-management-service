using System.Collections.Generic;
using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Dtos;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

public interface IProgramRepository : IGenericRepository<Program>
{
    Task<PaginationDto<Program>> PaginationAsync(int limit, int pageNumber);

    Task<List<Program>> WeekScheduleAsync();
}