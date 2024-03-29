using System;
using MediatR;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;

public sealed class BroadcastDeleteRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}