using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramUpdateRequests;

public sealed class ProgramUpdateRequest : IRequest<bool>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public Guid HeroImageId { get; set; }

    [JsonRequired]
    public DateTime Date { get; set; }

    [JsonRequired]
    public List<ProgramUpdateRequestBroadcast> Broadcasts { get; set; } = [];
}