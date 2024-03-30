using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

public sealed class ProgramGetWeekScheduleResponseProgram
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
    public List<ProgramGetWeekScheduleResponseProgramBroadcast> Broadcasts { get; set; } = [];
}