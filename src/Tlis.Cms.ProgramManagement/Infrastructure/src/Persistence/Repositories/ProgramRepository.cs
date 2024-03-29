using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories;

internal sealed class ProgramRepository(ProgramManagementDbContext dbContext)
    : GenericRepository<Program>(dbContext), IProgramRepository
{
    public override Task<Program?> GetByIdAsync(Guid id, bool asTracking)
    {
        var query = ConfigureTracking(DbSet.AsQueryable(), asTracking);

        return query
            .Include(x => x.Broadcasts)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}