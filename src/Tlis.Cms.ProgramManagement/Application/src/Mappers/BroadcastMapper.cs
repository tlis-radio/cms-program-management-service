using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

namespace Tlis.Cms.ProgramManagement.Application.Mappers;

public static class BroadcastMapper
{
    public static Broadcast ToEntity(BroadcastCreateRequest request)
    {
        return new Broadcast
        {
            Name = request.Name,
            ExternalUrl = string.Empty, // TODO: sem sa budu davat veci ako url na slido atd.
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            ShowId = request.ShowId
        };
    }

    public static BroadcastDetailsGetResponse? ToBroadcastDetailsGetResponse(
        Broadcast? entity,
        ImageDto? imageDto,
        ShowDto show)
    {
        if (entity is null)
        {
            return null;
        }

        var response =  new BroadcastDetailsGetResponse
        {
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Show = new BroadcastDetailsGetResponseShow
            {
                Id = show.Id,
                Name = show.Name
            }
        };

        if (imageDto != null)
        {
            response.Image = new BroadcastDetailsGetResponseImage
            {
                Id = imageDto.Id,
                Url = imageDto.Url
            };
        }

        return response;
    }

    public static BroadcastPaginationGetResponse ToPaginationDto(Broadcast entity)
    {
        return new BroadcastPaginationGetResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            ShowId = entity.ShowId
        };
    }
}