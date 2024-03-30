using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

public sealed class ProgramGetWeekScheduleResponseProgramBroadcastShow
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Name { get; set; }

    [JsonRequired]
    public required string Description { get; set; }

    [JsonRequired]
    public List<ProgramGetWeekScheduleResponseProgramBroadcastShowModerator> Moderators { get; set; } = [];

    [JsonRequired]
    public DateOnly CreatedDate { get; set; }

    public Guid? ProfileImageId { get; set; }
}