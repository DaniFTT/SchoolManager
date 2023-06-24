using FluentValidation;
using SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.UpdateSchoolClass
{
    internal class UpdateSchoolClassCommandValidator : AbstractValidator<UpdateSchoolClassCommand>
    {
        public UpdateSchoolClassCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("A Turma é obrigatória");

            RuleFor(p => p.CourseId)
                .GreaterThan(0).WithMessage("O Curso é obrigatório");

            RuleFor(p => p.ClassName)
                .NotEmpty().WithMessage("O Nome da Turma é obrigatório")
                .MaximumLength(255).WithMessage("O Nome deve conter no máximo 255 caracteres");

            RuleFor(p => p.Year)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Selecione um Ano maior ou igual ao atual");
        }
    }
}
