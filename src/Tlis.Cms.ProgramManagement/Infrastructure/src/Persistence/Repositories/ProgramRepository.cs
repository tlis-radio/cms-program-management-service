using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Dtos;
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

    public async Task<PaginationDto<Program>> PaginationAsync(int limit, int pageNumber)
    {
        var queryGetTotalCount = await ConfigureTracking(DbSet.AsQueryable(), false).CountAsync();
        
        var pageQuery = ConfigureTracking(DbSet.AsQueryable(), false);

        var page = await pageQuery
            .Include(x => x.Broadcasts)
            .OrderBy(u => u.Date)
            .Skip(limit * (pageNumber - 1))
            .Take(limit)
            .ToListAsync();
        
        return new PaginationDto<Program>
        {
            Total = queryGetTotalCount,
            Limit = limit,
            Page = pageNumber,
            Results = page
        };
    }

    public async Task<List<Program>> WeekScheduleAsync()
    {
        var today = new DateTime(
            DateTime.Today.Year,
            DateTime.Today.Month,
            DateTime.Today.Day,
            DateTime.Today.Hour,
            DateTime.Today.Minute,
            DateTime.Today.Second,
            DateTimeKind.Utc);

        var monday = today.AddDays(-GetDayOfWeek(today.DayOfWeek) + GetDayOfWeek(DayOfWeek.Monday));
        var saturday = monday.AddDays(6);

        var query = ConfigureTracking(DbSet.AsQueryable(), false);

        return await query
            .Include(x => x.Broadcasts)
            .Where(x => x.Date >= monday && x.Date <= saturday)
            .ToListAsync();
    }

    private int GetDayOfWeek(DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            DayOfWeek.Monday => 0,
            DayOfWeek.Tuesday => 1,
            DayOfWeek.Wednesday => 2,
            DayOfWeek.Thursday => 3,
            DayOfWeek.Friday => 4,
            DayOfWeek.Saturday => 5,
            DayOfWeek.Sunday => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
        };
    }
}