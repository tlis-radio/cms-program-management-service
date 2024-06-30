using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Interfaces;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class BroadcastDetailsGetRequestHandler(
    IUnitOfWork unitOfWork,
    IImageManagementHttpService imageManagementHttpService,
    IShowManagementHttpService showManagementHttpService) : IRequestHandler<BroadcastDetailsGetRequest, BroadcastDetailsGetResponse?>
{
    public async Task<BroadcastDetailsGetResponse?> Handle(BroadcastDetailsGetRequest request, CancellationToken cancellationToken)
    {
        var broadcast = await unitOfWork.BroadcastRepository.GetByIdAsync(request.Id, asTracking: false);

        var image = broadcast != null && broadcast.ImageId.HasValue
            ? await imageManagementHttpService.GetImageAsync(broadcast.ImageId.Value)
            : null;

        var show = broadcast != null
            ? await showManagementHttpService.GetShowAsync(broadcast.ShowId)
            : null;

        if (show is null)
        {
            throw new NullReferenceException(nameof(show));
        }

        return BroadcastMapper.ToBroadcastDetailsGetResponse(broadcast, image, show);
    }
}