using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Interfaces;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramGetWeekScheduleRequestHandler(
    IImageManagementHttpService imageManagementHttpService,
    IShowManagementHttpService showManagementHttpService,
    IUnitOfWork unitOfWork) : IRequestHandler<ProgramGetWeekScheduleRequest, ProgramGetWeekScheduleResponse>
{
    public async Task<ProgramGetWeekScheduleResponse> Handle(ProgramGetWeekScheduleRequest request, CancellationToken cancellationToken)
    {
        var weekSchedule = await unitOfWork.ProgramRepository.WeekScheduleAsync();

        var result = weekSchedule
            .Select(async x => await ProcessDayFromWeekScheduleAsync(x))
            .Select(x => x.Result)
            .ToDictionary(x => x.Key, x => x.Value);

        result.TryGetValue(DayOfWeek.Monday, out var monday);
        result.TryGetValue(DayOfWeek.Tuesday, out var tuesday);
        result.TryGetValue(DayOfWeek.Wednesday, out var wednesday);
        result.TryGetValue(DayOfWeek.Thursday, out var thursday);
        result.TryGetValue(DayOfWeek.Friday, out var friday);
        result.TryGetValue(DayOfWeek.Saturday, out var saturday);
        result.TryGetValue(DayOfWeek.Sunday, out var sunday);

        return new ProgramGetWeekScheduleResponse
        {
            Monday = monday,
            Tuesday = tuesday,
            Wednesday = wednesday,
            Thursday = thursday,
            Friday = friday,
            Saturday = saturday,
            Sunday = sunday
        };
    }

    private async Task<KeyValuePair<DayOfWeek, ProgramGetWeekScheduleResponseProgram?>> ProcessDayFromWeekScheduleAsync(Program program)
    {
        var heroImage = await imageManagementHttpService.GetImageAsync(program.HeroImageId);

        var shows = program.Broadcasts.Select(x => showManagementHttpService.GetShowAsync(x.ShowId)).ToList();

        await Task.WhenAll(shows);

        var showsDict = shows.Select(x => x.Result).ToDictionary(x => x.Id, x => x);

        var response = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(program, heroImage, showsDict);

        return new KeyValuePair<DayOfWeek, ProgramGetWeekScheduleResponseProgram?>(program.Date.DayOfWeek, response);
    }
}