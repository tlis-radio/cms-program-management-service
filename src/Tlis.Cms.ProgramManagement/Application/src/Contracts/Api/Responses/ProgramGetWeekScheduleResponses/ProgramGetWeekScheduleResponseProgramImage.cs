using System;
using System.Text.Json.Serialization;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

public sealed class ProgramGetWeekScheduleResponseProgramImage
{
    [JsonRequired]
    public Guid Id { get; set; }

    [JsonRequired]
    public int Width { get; set; }

    [JsonRequired]
    public int Height { get; set; }

    [JsonRequired]
    public required string Url { get; set; }
}