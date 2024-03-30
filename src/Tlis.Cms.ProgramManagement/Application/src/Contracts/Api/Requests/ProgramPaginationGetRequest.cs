using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramPaginationGetResponses;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class ProgramPaginationGetRequest : IRequest<PaginationResponse<ProgramPaginationGetResponse>>
{
    [Required]
    public int Limit { get; set; }

    [Required] [Range(1, int.MaxValue)]
    public int Page { get; set; }
}