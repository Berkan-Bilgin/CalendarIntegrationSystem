using Application.Features.Calendar.Events.Commands.Create;
using Application.Features.Calendar.Events.Commands.Delete;
using Application.Features.Calendar.Events.Commands.Update;
using Application.Features.Calendar.Events.Queries.GetListByUserId;
using Application.Features.Calendar.Tasks.Commands.Create;
using Application.Features.Calendar.Tasks.Commands.Delete;
using Application.Features.Calendar.Tasks.Queries.GetListByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("tasks")]
        public async Task<IActionResult> CreateEvent(CreateTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPatch("tasks")]
        public async Task<IActionResult> Update(UpdateTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteTaskCommand command = new() { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetTaskListByUserId([FromQuery] GetTaskListByUserIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
