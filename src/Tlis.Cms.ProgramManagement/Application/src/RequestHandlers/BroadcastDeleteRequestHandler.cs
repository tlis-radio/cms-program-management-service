using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramDeleteRequBroadcastDeleteRequestHandlerestHandler(IUnitOfWork unitOfWork) : IRequestHandler<BroadcastDeleteRequest, bool>
{
    public async Task<bool> Handle(BroadcastDeleteRequest request, CancellationToken cancellationToken)
    {
        var deleted = await unitOfWork.BroadcastRepository.DeleteByIdAsync(request.Id);
        await unitOfWork.SaveChangesAsync();

        return deleted;
    }
}