using System;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Configurations;

internal sealed class HttpServiceConfiguration
{
    public required Uri BaseAddress { get; set; }
}