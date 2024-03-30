using MediatR;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class ProgramGetWeekScheduleRequest : IRequest<ProgramGetWeekScheduleResponse>
{
}