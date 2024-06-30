using System;
using System.ComponentModel.DataAnnotations;

namespace Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

public sealed class BroadcastDetailsGetResponseImage
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public required string Url { get; set; }
}