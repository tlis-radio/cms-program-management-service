using System;
using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Interfaces;

public interface IImageManagementHttpService
{
    Task<ImageDto> GetImageAsync(Guid id);
}