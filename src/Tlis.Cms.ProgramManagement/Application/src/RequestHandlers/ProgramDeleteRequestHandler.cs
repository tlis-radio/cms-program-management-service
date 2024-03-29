using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramDeleteRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProgramDeleteRequest, bool>
{
    public async Task<bool> Handle(ProgramDeleteRequest request, CancellationToken cancellationToken)
    {
        var deleted = await unitOfWork.ProgramRepository.DeleteByIdAsync(request.Id);
        await unitOfWork.SaveChangesAsync();

        return deleted;
    }
}