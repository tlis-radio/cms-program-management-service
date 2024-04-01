namespace Tlis.Cms.ProgramManagement.Infrastructure.Configurations;

internal sealed class CmsServicesConfiguration
{
    public required HttpServiceConfiguration ShowManagement { get; set; }

    public required HttpServiceConfiguration ImageAssetManagement { get; set; }
}