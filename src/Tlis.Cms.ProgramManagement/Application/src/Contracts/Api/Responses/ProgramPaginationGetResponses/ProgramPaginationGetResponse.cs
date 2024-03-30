using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramPaginationGetResponses;

public sealed class ProgramPaginationGetResponse
{
    [JsonRequired]
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
    public List<ProgramPaginationGetResponseBroadcast> Broadcasts { get; set; } = [];
}