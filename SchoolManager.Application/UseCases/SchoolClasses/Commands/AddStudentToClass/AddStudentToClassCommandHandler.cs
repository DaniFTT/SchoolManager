using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveSchoolClass;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.AddStudentToClass
{
    public sealed class AddStudentToClassCommandHandler : IRequestHandler<AddStudentToClassCommand, Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IStudentRepository _studentRepository;

        public AddStudentToClassCommandHandler(ISchoolClassRepository schoolClassRepository, 
            IStudentRepository studentRepository)
        {
            _schoolClassRepository = schoolClassRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(AddStudentToClassCommand command,
            CancellationToken cancellationToken)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(command.classId);
            var student = await _studentRepository.GetByIdAsync(command.studentId);

            if (schoolClass is null || student is null)
                return Result.NotFound("A Turma ou Aluno não foram encontrados!");

            var studentAlreadyInClass = await _studentRepository.GetStudentByClassAsync(schoolClass.Id, student.Id) is not null;
            if (studentAlreadyInClass)
                return Result.Conflict("Esse Aluno já pertence a essa Turma!");

            await _schoolClassRepository.AddStudentToClass(schoolClass.Id, student.Id);

            return Result.Success();
        }
    }
}
