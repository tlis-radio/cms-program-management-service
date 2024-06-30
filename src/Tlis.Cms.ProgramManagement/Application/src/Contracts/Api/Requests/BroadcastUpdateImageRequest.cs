using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class BroadcastUpdateImageRequest : IRequest<bool>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonRequired]
    public Guid ImageId { get; set; }
}