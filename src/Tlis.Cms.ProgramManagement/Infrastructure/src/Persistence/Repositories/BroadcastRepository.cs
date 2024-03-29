using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories;

internal sealed class BroadcastRepository(ProgramManagementDbContext dbContext)
    : GenericRepository<Broadcast>(dbContext), IBroadcastRepository;