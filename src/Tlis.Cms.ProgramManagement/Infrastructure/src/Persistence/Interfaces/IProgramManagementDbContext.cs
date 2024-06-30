using Microsoft.EntityFrameworkCore;
using Tlis.Cms.ProgramManagement.Domain.Entities;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

public interface IProgramManagementDbContext
{
    public DbSet<Broadcast> Broadcast { get; set; }

    public int SaveChanges();
}