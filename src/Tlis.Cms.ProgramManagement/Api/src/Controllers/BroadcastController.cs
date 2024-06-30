using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tlis.Cms.ProgramManagement.Api.Constants;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Api.Controllers.Base;

[ApiController]
[Route("[controller]")]
public sealed class BroadcastController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(BroadcastDetailsGetRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Get broadcast's details")]
    public ValueTask<ActionResult<BroadcastDetailsGetResponse>> GetShowDetails([FromRoute] Guid id)
        => HandleGet(new BroadcastDetailsGetRequest { Id = id });

    [HttpGet("pagination")]
    [AllowAnonymous]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PaginationResponse<BroadcastPaginationGetResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Paging broadcast's")]
    public ValueTask<ActionResult<PaginationResponse<BroadcastPaginationGetResponse>>> Pagination([FromQuery] BroadcastPaginationGetRequest request)
        => HandleGet(request);

    [HttpPost]
    [Authorize(Policy.ProgramWrite)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Create broadcast")]
    public ValueTask<ActionResult<BaseCreateResponse>> CreateShow([FromBody, Required] BroadcastCreateRequest request)
        => HandlePost(request);

    [HttpPut("{id:guid}")]
    [Authorize(Policy.ProgramWrite)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Update broadcast's details")]
    public ValueTask<ActionResult> UpdateShow([FromRoute] Guid id, [FromBody, Required] BroadcastUpdateRequest request)
    {
        request.Id = id;

        return HandlePut(request);
    }

    [HttpPut("{id:guid}/profile-image")]
    [Authorize(Policy.ProgramWrite)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Update broadcast's image")]
    public ValueTask<ActionResult> UpdateBroadcastImage([FromRoute] Guid id, [FromBody, Required] BroadcastUpdateImageRequest request)
    {
        request.Id = id;

        return HandlePut(request);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy.ProgramDelete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Delete program")]
    public ValueTask<ActionResult> DeleteBroadcast([FromRoute] Guid id)
        => HandleDelete(new BroadcastDeleteRequest { Id = id });
}