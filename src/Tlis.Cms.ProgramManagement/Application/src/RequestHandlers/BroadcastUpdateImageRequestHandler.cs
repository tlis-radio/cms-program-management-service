using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class BroadcastUpdateImageRequestHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<BroadcastUpdateImageRequest, bool>
{
    public async Task<bool> Handle(BroadcastUpdateImageRequest request, CancellationToken cancellationToken)
    {
        var toUpdate = await unitOfWork.BroadcastRepository.GetByIdAsync(request.Id, true);
        if (toUpdate is null)
        {
            return false;
        }

        toUpdate.ImageId = request.ImageId;

        await unitOfWork.SaveChangesAsync();

        return true;
    }
}