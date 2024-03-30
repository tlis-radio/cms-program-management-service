using System;
using System.Collections.Generic;
using Tlis.Cms.ProgramManagement.Domain.Entities.Base;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Dtos;

public class PaginationDto<TEntity> where TEntity : BaseEntity
{
    public int Page { get; set; }

    public int Limit { get; set; }
    
    public int Total { get; set; }
    
    public int TotalPages => Limit > 0 ? (int)Math.Ceiling((double)Total / Limit) : 0;

    public List<TEntity> Results { get; set; } = [];
}