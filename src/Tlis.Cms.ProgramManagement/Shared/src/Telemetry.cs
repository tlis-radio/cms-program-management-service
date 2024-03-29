using System.Diagnostics;

namespace Tlis.Cms.ProgramManagement.Shared;

public static class Telemetry
{
    public static readonly string ServiceName = "cms-program-management-service";

    public static readonly ActivitySource ActivitySource = new(ServiceName);
}