using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class BroadcastPaginationGetRequestHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<BroadcastPaginationGetRequest, PaginationResponse<BroadcastPaginationGetResponse>>
{
    public async Task<PaginationResponse<BroadcastPaginationGetResponse>> Handle(BroadcastPaginationGetRequest request, CancellationToken cancellationToken)
    {
        var shows = await unitOfWork.BroadcastRepository.PaginationAsync(request.Limit, request.Page);

        return new PaginationResponse<BroadcastPaginationGetResponse>
        {
            Total = shows.Total,
            Limit = shows.Limit,
            Page = shows.Page,
            TotalPages = shows.TotalPages,
            Results = shows.Results.Select(BroadcastMapper.ToPaginationDto).ToImmutableList()
        };
    }
}