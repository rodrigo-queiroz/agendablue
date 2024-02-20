using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScheduleBlue.Application.Commands.AddUser;
using ScheduleBlue.Application.Commands.DeleteUser;
using ScheduleBlue.Application.Commands.UpdateUser;
using ScheduleBlue.Application.Queries.GetAllSchedule;
using ScheduleBlue.Application.Queries.GetScheduleById;
using ScheduleBlue.Core.Entities;

namespace ScheduleBlue.API.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAll()
        {
            GetAllScheduleQuery getAllScheduleQuery = new();
            List<Schedule> projects = await _mediator.Send(getAllScheduleQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetScheduleByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
