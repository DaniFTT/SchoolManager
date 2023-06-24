using FluentValidation;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.UpdateSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.AddStudentToClass
{

    internal class AddStudentToClassCommandValidator : AbstractValidator<AddStudentToClassCommand>
    {
        public AddStudentToClassCommandValidator()
        {
            RuleFor(p => p.classId).GreaterThan(0).WithMessage("A Turma é obrigatória");
            RuleFor(p => p.studentId).GreaterThan(0).WithMessage("O Aluno é obrigatório");
        }
    }
}
