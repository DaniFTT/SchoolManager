using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveSchoolClass;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveStudentFromClass
{

    public sealed class RemoveStudentFromClassCommandHandler : IRequestHandler<RemoveStudentFromClassCommand, Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IStudentRepository _studentRepository;

        public RemoveStudentFromClassCommandHandler(ISchoolClassRepository schoolClassRepository,
            IStudentRepository studentRepository)
        {
            _schoolClassRepository = schoolClassRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(RemoveStudentFromClassCommand command,
            CancellationToken cancellationToken)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(command.classId);
            var student = await _studentRepository.GetByIdAsync(command.studentId);

            if (schoolClass is null || student is null)
                return Result.NotFound("A Turma ou Aluno não foram encontrados!");

            var studentIsNotInClass = await _studentRepository.GetStudentByClassAsync(schoolClass.Id, student.Id) is null;
            if (studentIsNotInClass)
                return Result.Error("Esse Aluno não pertence a essa Turma!");

            await _schoolClassRepository.RemoveStudentFromClass(schoolClass.Id, student.Id);

            return Result.Success();
        }
    }
}
