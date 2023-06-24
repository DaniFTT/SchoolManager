using FluentValidation;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass
{
    internal class CreateSchoolClassCommandValidator : AbstractValidator<CreateSchoolClassCommand>
    {
        public CreateSchoolClassCommandValidator()
        {
            RuleFor(p => p.CourseId)
                .GreaterThan(0).WithMessage("O Curso é obrigatório");

            RuleFor(p => p.ClassName)
                .NotEmpty().WithMessage("O Nome da Turma é obrigatório")
                .MaximumLength(45).WithMessage("O Nome da Turma deve conter no máximo 45 caracteres");

            RuleFor(p => p.Year)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Selecione um Ano maior ou igual ao atual");
        }
    }
}
