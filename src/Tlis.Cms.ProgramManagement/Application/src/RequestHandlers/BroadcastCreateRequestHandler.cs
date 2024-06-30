using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class BroadcastCreateRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<BroadcastCreateRequest, BaseCreateResponse>
{
    public async Task<BaseCreateResponse> Handle(BroadcastCreateRequest request, CancellationToken cancellationToken)
    {
        var broadcast = BroadcastMapper.ToEntity(request);

        await unitOfWork.BroadcastRepository.InsertAsync(broadcast);
        await unitOfWork.SaveChangesAsync();

        return new BaseCreateResponse
        {
            Id = broadcast.Id,
        };
    }
}