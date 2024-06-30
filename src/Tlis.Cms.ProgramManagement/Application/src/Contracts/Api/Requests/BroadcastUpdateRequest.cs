using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class BroadcastUpdateRequest : IRequest<bool>
{
    [JsonIgnore]
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