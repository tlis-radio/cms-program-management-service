using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramCreateRequests;

public sealed class ProgramCreateRequest : IRequest<BaseCreateResponse>
{
    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public Guid HeroImageId { get; set; }

    [JsonRequired]
    public DateTime Date { get; set; }

    [JsonRequired]
    public List<ProgramCreateRequestBroadcast> Broadcasts { get; set; } = [];
}