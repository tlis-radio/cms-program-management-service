using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

public sealed class ShowModeratorDto
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Nickname { get; set; }
}