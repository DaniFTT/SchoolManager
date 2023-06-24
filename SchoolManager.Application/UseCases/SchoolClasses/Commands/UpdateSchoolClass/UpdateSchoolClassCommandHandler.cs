using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass;
using SchoolManager.Application.UseCases.Students.Commands.UpdateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.UpdateSchoolClass
{
    public sealed class UpdateSchoolClassCommandHandler : IRequestHandler<UpdateSchoolClassCommand, Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public UpdateSchoolClassCommandHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<Result> Handle(UpdateSchoolClassCommand updateStudentCommand,
            CancellationToken cancellationToken)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(updateStudentCommand.Id);
            if (schoolClass is null)
                return Result.NotFound("Turma não encontrada!");

            if(schoolClass.ClassName != updateStudentCommand.ClassName)
            {
                var schoolClassAreadyExists = await _schoolClassRepository.SchoolClassExistsByName(updateStudentCommand.ClassName!);
                if (schoolClassAreadyExists)
                    return Result.Conflict("Nome de Turma já utilizado. Escolha um novo!");
            }

            schoolClass.UpdateSchoolClass(updateStudentCommand.CourseId, updateStudentCommand.ClassName!, updateStudentCommand.Year);

            var operationSucceded = await _schoolClassRepository.UpdateAsync(schoolClass);

            return operationSucceded ? Result.Success() : Result.Error(GlobaErrors.BaseError);
        }
    }
}
