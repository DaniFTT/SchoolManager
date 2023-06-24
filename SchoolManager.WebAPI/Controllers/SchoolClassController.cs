using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.AddStudentToClass;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveSchoolClass;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveStudentFromClass;
using SchoolManager.Application.UseCases.SchoolClasses.Queries.GetAllSchoolClasses;
using SchoolManager.Application.UseCases.SchoolClasses.Queries.GetSchoolClassById;
using SchoolManager.Application.UseCases.Students.Commands.InactivateStudent;
using SchoolManager.Application.UseCases.Students.Queries.GetAllStudents;
using SchoolManager.Application.UseCases.Students.Queries.GetStudentById;
using SchoolManager.Domain.Entities;
using SchoolManager.WebAPI.Configs.Extensions;
using SchoolManager.WebAPI.Models.Shared;
using SchoolManager.WebAPI.Models.ShoolClassModels;
using SchoolManager.WebAPI.Models.StudentModels;

namespace SchoolManager.WebAPI.Controllers
{
    [ApiController]
    [Route(Routes.SchoolClassUri)]
    public class SchoolClassController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SchoolClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<SchoolClass>> CreateSchoolClassAsync([FromBody] CreateSchoolClassRequest createSchoolClassRequest,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(createSchoolClassRequest.ToCommand(), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSchoolClassAsync(int id, [FromBody] UpdateSchoolClassRequest updateSchoolClassRequest,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(updateSchoolClassRequest.ToCommand(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveSchoolClassAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new RemoveSchoolClassCommand(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SchoolClass>> GetSchoolClassByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetSchoolClassByIdQuery(id), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<SchoolClass>>> GetAllSchoolClassesAsync(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllSchoolClassesQuery(), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpPost("{classId}/addstudent/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddStudentToClassAsync(int classId, int studentId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new AddStudentToClassCommand(classId, studentId), cancellationToken);

            return HandleResult(result).Return();
        }

        [HttpDelete("{classId}/removestudent/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveStudentFromClassAsync(int classId, int studentId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new RemoveStudentFromClassCommand(classId, studentId), cancellationToken);

            return HandleResult(result).Return();
        }
    }
}
