using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Requests.ProgramCreateRequests;
using Tlis.Cms.ProgramManagement.Application.Contracts.Api.Responses;

namespace Tlis.Cms.ProgramManagement.Api.Controllers.Base;

[ApiController]
[Route("[controller]")]
public sealed class BroadcastController(IMediator mediator) : BaseController(mediator)
{
    [HttpDelete("{id:guid}")]
    // [Authorize(Policy.ProgramDelete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation("Delete program")]
    public ValueTask<ActionResult> DeleteBroadcast([FromRoute] Guid id)
        => HandleDelete(new BroadcastDeleteRequest { Id = id });
}