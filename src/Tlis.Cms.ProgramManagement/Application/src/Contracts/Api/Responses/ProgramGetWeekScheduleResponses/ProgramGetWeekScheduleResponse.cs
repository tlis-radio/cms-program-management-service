namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

public sealed class ProgramGetWeekScheduleResponse
{
    public ProgramGetWeekScheduleResponseProgram? Monday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Tuesday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Wednesday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Thursday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Friday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Saturday { get; set; }

    public ProgramGetWeekScheduleResponseProgram? Sunday { get; set; }
}