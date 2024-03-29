using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramUpdateRequests;

public sealed class ProgramUpdateRequestBroadcast
{
    public Guid? Id { get; set; }

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