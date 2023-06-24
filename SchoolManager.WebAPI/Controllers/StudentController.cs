using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Application.UseCases.Students.Commands.InactivateStudent;
using SchoolManager.Application.UseCases.Students.Queries.GetAllStudents;
using SchoolManager.Application.UseCases.Students.Queries.GetStudentById;
using SchoolManager.Application.UseCases.Students.Queries.GetStudentsByClass;
using SchoolManager.Domain.Entities;
using SchoolManager.WebAPI.Configs.Extensions;
using SchoolManager.WebAPI.Models.Shared;
using SchoolManager.WebAPI.Models.StudentModels;

namespace SchoolManager.WebAPI.Controllers
{
    [ApiController]
    [Route(Routes.StudentUri)]
    public class StudentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Student>> CreateStudentAsync([FromBody] CreateStudentRequest createStudentRequest,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(createStudentRequest.ToCommand(), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateStudentAsync(int id, [FromBody] UpdateStudentRequest updateStudentRequest,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(updateStudentRequest.ToCommand(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveStudentAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new RemoveStudentCommand(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetAllStudentsAsync(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllStudentsQuery(), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpGet("studentbyclass/{classId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetStudentsByClass(int classId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllStudentsByClassQuery(classId), cancellationToken);

            return HandleResult(result).Return();
        }
    }
}
