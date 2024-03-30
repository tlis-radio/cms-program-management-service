using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramPaginationGetResponses;

public sealed class ProgramPaginationGetResponseBroadcast
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public DateTime StartDate { get; set; }

    [JsonRequired]
    public DateTime EndDate { get; set; }

    [JsonRequired]
    public Guid ShowId { get; set; }
}