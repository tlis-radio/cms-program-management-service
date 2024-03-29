using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramUpdateRequests;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramUpdateRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProgramUpdateRequest, bool>
{
    public async Task<bool> Handle(ProgramUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await unitOfWork.ProgramRepository.GetByIdAsync(request.Id, asTracking: true);

        if (existing == null)
        {
            return false;
        }

        ProgramMapper.MapToExistingProgram(existing, request);
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}