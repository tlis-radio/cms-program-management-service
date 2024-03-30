using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Tlis.Cms.ProgramManagement.Infrastructure.Configurations;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Base;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices;

internal sealed class ImageManagementHttpService(
    HttpClient client,
    IOptions<CmsServicesConfiguration> options)
    : BaseHttpService(client, options.Value.ImageManagement), IImageManagementHttpService
{
    public Task<ImageDto> GetImageAsync(Guid id) => GetAsync<ImageDto>($"/image/{id}");
}