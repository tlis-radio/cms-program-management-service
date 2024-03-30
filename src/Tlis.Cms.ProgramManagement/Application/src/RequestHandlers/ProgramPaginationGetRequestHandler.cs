using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramPaginationGetResponses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramPaginationGetRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProgramPaginationGetRequest, PaginationResponse<ProgramPaginationGetResponse>>
{
    public async Task<PaginationResponse<ProgramPaginationGetResponse>> Handle(ProgramPaginationGetRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.ProgramRepository.PaginationAsync(request.Limit, request.Page);

        return new PaginationResponse<ProgramPaginationGetResponse>
        {
            Total = result.Total,
            Limit = result.Limit,
            Page = result.Page,
            TotalPages = result.TotalPages,
            Results = result.Results.Select(ProgramMapper.MapToProgramPaginationGetResponse).ToImmutableList()
        };
    }
}