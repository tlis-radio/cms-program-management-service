using System;
using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Interfaces;

public interface IShowManagementHttpService
{
    Task<ShowDto> GetShowAsync(Guid id);
}