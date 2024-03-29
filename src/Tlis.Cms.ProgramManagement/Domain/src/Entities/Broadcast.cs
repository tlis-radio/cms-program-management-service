using System;
using Tlis.Cms.ProgramManagement.Domain.Entities.Base;

namespace Tlis.Cms.ProgramManagement.Domain.Entities;

public class Broadcast : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid ShowId { get; set; }

    public Guid ProgramId { get; set; }
}