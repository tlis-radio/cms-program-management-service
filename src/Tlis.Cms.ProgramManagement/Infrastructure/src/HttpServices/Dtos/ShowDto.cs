using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

public sealed class ShowDto
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public List<ShowModeratorDto> Moderators { get; set; } = [];

    [JsonRequired]
    public DateOnly CreatedDate { get; set; }

    public Guid? ProfileImageId { get; set; }
}