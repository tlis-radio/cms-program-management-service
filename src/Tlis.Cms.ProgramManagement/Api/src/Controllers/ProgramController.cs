using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramCreateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramUpdateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Api.Controllers.Base;

[ApiController]
[Route("[controller]")]
public sealed class ProgramController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    // [Authorize(Policy.ProgramWrite)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Create program")]
    public ValueTask<ActionResult<BaseCreateResponse>> CreateProgram([FromBody, Required] ProgramCreateRequest request)
        => HandlePost(request);

    [HttpPut("{id:guid}")]
    // [Authorize(Policy.ProgramWrite)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Update program")]
    public ValueTask<ActionResult> UpdateShow([FromRoute] Guid id, [FromBody, Required] ProgramUpdateRequest request)
    {
        request.Id = id;

        return HandlePut(request);
    }

    [HttpDelete("{id:guid}")]
    // [Authorize(Policy.ProgramDelete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Delete program")]
    public ValueTask<ActionResult> DeleteProgram([FromRoute] Guid id)
        => HandleDelete(new ProgramDeleteRequest { Id = id });
}