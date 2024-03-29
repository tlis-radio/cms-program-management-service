using System;
using System.Collections.Generic;
using Tlis.Cms.ProgramManagement.Domain.Entities.Base;

namespace Tlis.Cms.ProgramManagement.Domain.Entities;

public class Program : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid HeroImageId { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<Broadcast> Broadcasts { get; set; } = [];
}