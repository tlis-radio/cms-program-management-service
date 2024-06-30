using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Repositories.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork
{
    IBroadcastRepository BroadcastRepository { get; }

    void SetStateUnchanged<TEntity>(params TEntity[] entities) where TEntity : class;

    /// <exception cref="EntityAlreadyExistsException">Thrown when a unique constraint is violated</exception>
    /// <exception cref="ApiException">Thrown when an error occurs while saving changes</exception>
    public Task SaveChangesAsync();

    public Task ExecutePendingMigrationsAsync();
}