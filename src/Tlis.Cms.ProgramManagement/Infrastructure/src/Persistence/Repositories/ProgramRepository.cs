using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories;

internal sealed class ProgramRepository(ProgramManagementDbContext dbContext)
    : GenericRepository<Program>(dbContext), IProgramRepository;