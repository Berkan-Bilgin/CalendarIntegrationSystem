using Application.Features.Calendar.Events.Commands.Create;
using Application.Features.Calendar.Events.Commands.Delete;
using Application.Features.Calendar.Events.Commands.Update;
using Application.Features.Calendar.Events.Queries.GetListByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("events")]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPatch("events")]
        public async Task<IActionResult> Update(UpdateEventCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("events/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteEventCommand command = new() { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEventListByUserId([FromQuery] GetEventListByUserIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
