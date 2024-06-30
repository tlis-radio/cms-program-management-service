using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

public sealed class BroadcastDetailsGetResponse
{
    [JsonRequired]
    public Guid Id { get; set; }

    public BroadcastDetailsGetResponseImage? Image { get; set; }

    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public DateTime StartDate { get; set; }

    [JsonRequired]
    public DateTime EndDate { get; set; }

    [JsonRequired]
    public required BroadcastDetailsGetResponseShow Show { get; set; }
}