using System;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class BroadcastDetailsGetRequest : IRequest<BroadcastDetailsGetResponse?>
{
    public Guid Id { get; set; }
}