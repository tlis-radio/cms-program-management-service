using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class BroadcastPaginationGetRequest : IRequest<PaginationResponse<BroadcastPaginationGetResponse>>
{
    [Required]
    public int Limit { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Page { get; set; }
}