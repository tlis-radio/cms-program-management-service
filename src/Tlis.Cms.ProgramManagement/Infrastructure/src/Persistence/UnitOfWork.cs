using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tlis.Cms.ProgramManagement.Infrastructure.Exceptions;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    public IBroadcastRepository BroadcastRepository => _lazyBroadcastRepository.Value;
    
    private readonly Lazy<IBroadcastRepository> _lazyBroadcastRepository;

    private bool _disposed;

    private readonly ILogger<UnitOfWork> _logger;

    private readonly ProgramManagementDbContext _dbContext;

    public UnitOfWork(ProgramManagementDbContext dbContext, ILogger<UnitOfWork> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        _lazyBroadcastRepository = new(() => new BroadcastRepository(_dbContext));
    }

    public void SetStateUnchanged<TEntity>(params TEntity[] entities) where TEntity : class
    {
        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Unchanged;
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError("{Exception}", exception.Message);
            
            throw exception switch
            {
                UniqueConstraintException => new EntityAlreadyExistsException(),
                DbUpdateConcurrencyException => new EntityNotFoundException(),
                _ => new Exception(exception.Message)
            };
        }
    }

    public async Task ExecutePendingMigrationsAsync()
    {
        var pendingMigrations = (await _dbContext.Database.GetPendingMigrationsAsync()).ToList();

        if (pendingMigrations.Any())
        {
            _logger.LogInformation("Applying migrations: {Join}", string.Join(',', pendingMigrations));

            await _dbContext.Database.MigrateAsync();
        }
        else
        {
            _logger.LogInformation("No migrations to execute");
        }
    }

    public void Dispose()
    {
        if (!_disposed)
            _dbContext.Dispose();

        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
