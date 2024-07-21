
using Application.Features.Calendar.CalendarItems.Queries.GetListByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CalendarItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalendarItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("calendarItems")]
        //public async Task<IActionResult> CreateCalendarItem(CreateCalendarItemCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpPatch("calendarItems")]
        //public async Task<IActionResult> Update(UpdateCalendarItemCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        //[HttpDelete("calendarItems/{id}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    DeleteCalendarItemCommand command = new() { Id = id };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpGet("calendarItems")]
        public async Task<IActionResult> GetCalendarItemListByUserId([FromQuery] GetCalendarItemListByUserIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
