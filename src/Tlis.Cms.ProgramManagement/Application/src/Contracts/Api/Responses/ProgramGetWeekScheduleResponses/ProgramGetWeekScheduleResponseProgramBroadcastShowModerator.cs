using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

public sealed class ProgramGetWeekScheduleResponseProgramBroadcastShowModerator
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public required string Nickname { get; set; }
}