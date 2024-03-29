using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramCreateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramCreateRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProgramCreateRequest, BaseCreateResponse>
{
    public async Task<BaseCreateResponse> Handle(ProgramCreateRequest request, CancellationToken cancellationToken)
    {
        var toAdd = ProgramMapper.MapToProgram(request);

        await unitOfWork.ProgramRepository.InsertAsync(toAdd);
        await unitOfWork.SaveChangesAsync();

        return new BaseCreateResponse
        {
            Id = toAdd.Id
        };
    }
}