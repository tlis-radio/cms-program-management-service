using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;
using Tlis.Cms.ProgramManagement.Application.Mappers;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Application.RequestHandlers;

internal sealed class ProgramGetWeekScheduleRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProgramGetWeekScheduleRequest, ProgramGetWeekScheduleResponse>
{
    public async Task<ProgramGetWeekScheduleResponse> Handle(ProgramGetWeekScheduleRequest request, CancellationToken cancellationToken)
    {
        var weekSchedule = await unitOfWork.ProgramRepository.WeekScheduleAsync();

        return new ProgramGetWeekScheduleResponse
        {
            Monday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Monday)),
            Tuesday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Tuesday)),
            Wednesday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Wednesday)),
            Thursday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Thursday)),
            Friday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Friday)),
            Saturday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Saturday)),
            Sunday = ProgramMapper.MapToProgramGetWeekScheduleResponseProgram(weekSchedule.FirstOrDefault(x => x.Date.DayOfWeek == DayOfWeek.Sunday))
        };
    }
}