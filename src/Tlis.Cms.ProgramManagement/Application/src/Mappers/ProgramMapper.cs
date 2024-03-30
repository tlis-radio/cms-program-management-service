using System;
using System.Collections.Generic;
using System.Linq;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramCreateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramUpdateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramGetWeekScheduleResponses;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses.ProgramPaginationGetResponses;
using Tlis.Cms.ProgramManagement.Domain.Entities;
using Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Dtos;

namespace Tlis.Cms.ProgramManagement.Application.Mappers;

internal static class ProgramMapper
{
    internal static ProgramGetWeekScheduleResponseProgram? MapToProgramGetWeekScheduleResponseProgram(
        Program? entity,
        ImageDto heroImage,
        Dictionary<Guid, ShowDto> shows)
    {
        if (entity == null)
        {
            return null;
        }

        return new ProgramGetWeekScheduleResponseProgram
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Date = entity.Date,
            HeroImage = new ProgramGetWeekScheduleResponseProgramImage
            {
                Id = heroImage.Id,
                Url = heroImage.Url,
                Height = heroImage.Height,
                Width = heroImage.Width
            },
            Broadcasts = entity.Broadcasts.Select(x => MapToProgramGetWeekScheduleResponseProgramBroadcast(x, shows)).ToList()
        };
    }

    internal static ProgramPaginationGetResponse MapToProgramPaginationGetResponse(Program entity)
    {
        return new ProgramPaginationGetResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Date = entity.Date,
            HeroImageId = entity.HeroImageId,
            Broadcasts = entity.Broadcasts.Select(MapToProgramPaginationGetResponseBroadcast).ToList()
        };
    }

    internal static void MapToExistingProgram(Program existing, ProgramUpdateRequest @new)
    {
        existing.Name = @new.Name;
        existing.Description = @new.Description;
        existing.Date = @new.Date;
        existing.HeroImageId = @new.HeroImageId;

        ResolveBroadcasts(existing, @new.Broadcasts);
    }

    internal static Program MapToProgram(ProgramCreateRequest request)
    {
        return new Program
        {
            Name = request.Name,
            Description = request.Description,
            Date = request.Date,
            HeroImageId = request.HeroImageId,
            Broadcasts = request.Broadcasts.Select(x => new Broadcast
            {
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ShowId = x.ShowId
            }).ToList()
        };
    }

    private static void ResolveBroadcasts(Program existing, List<ProgramUpdateRequestBroadcast> @new)
    {
        var toAdd = @new.Where(x => x.Id == null).Select(MapToBroadcast).ToList();

        var existingDict = existing.Broadcasts.ToDictionary(key => key.Id, value => value);
        var toUpdate = @new.Where(x => x.Id != null).Select(x => MapToExistingBroadcast(existingDict[x.Id!.Value], x)).ToList();

        existing.Broadcasts = [.. toAdd, .. toUpdate];
    }

    private static Broadcast MapToBroadcast(ProgramUpdateRequestBroadcast request)
    {
        return new Broadcast
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            ShowId = request.ShowId
        };
    }

    private static Broadcast MapToExistingBroadcast(Broadcast existing, ProgramUpdateRequestBroadcast @new)
    {
        existing.Name = @new.Name;
        existing.Description = @new.Description;
        existing.StartDate = @new.StartDate;
        existing.EndDate = @new.EndDate;
        existing.ShowId = @new.ShowId;

        return existing;
    }

    private static ProgramPaginationGetResponseBroadcast MapToProgramPaginationGetResponseBroadcast(Broadcast entity)
    {
        return new ProgramPaginationGetResponseBroadcast
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            ShowId = entity.ShowId
        };
    }

    private static ProgramGetWeekScheduleResponseProgramBroadcast MapToProgramGetWeekScheduleResponseProgramBroadcast(
        Broadcast entity,
        Dictionary<Guid, ShowDto> shows)
    {
        var found = shows.TryGetValue(entity.ShowId, out var showDto);

        if (!found || showDto == null)
        {
            throw new Exception("Show not found");
        }

        return new ProgramGetWeekScheduleResponseProgramBroadcast
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Show = new ProgramGetWeekScheduleResponseProgramBroadcastShow
            {
                Id = showDto.Id,
                Name = showDto.Name,
                Description = showDto.Description,
                CreatedDate = showDto.CreatedDate,
                ProfileImageId = showDto.ProfileImageId,
                Moderators = showDto.Moderators.Select(x => new ProgramGetWeekScheduleResponseProgramBroadcastShowModerator
                {
                    Id = x.Id,
                    Nickname = x.Nickname
                }).ToList()
            }
        };
    }
}