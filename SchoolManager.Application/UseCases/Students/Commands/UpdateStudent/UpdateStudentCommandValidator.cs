using FluentValidation;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.SharedKernel.Extesions;

namespace SchoolManager.Application.UseCases.Students.Commands.UpdateStudent
{
    internal class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("O Aluno é obrigatório");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(255).WithMessage("O Nome deve conter no máximo 255 caracteres");

            RuleFor(p => p.User)
                .NotEmpty().WithMessage("O Usuário é obrigatório")
                .MaximumLength(45).WithMessage("O Usuário deve conter no máximo 45 caracteres");
        }
    }

    internal class PasswordValidator : AbstractValidator<UpdateStudentCommand>
    {
        public PasswordValidator()
        {
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("A Senha é obrigatório")
                .MinimumLength(8).WithMessage("Sua Senha deve ter pelo menos 8 caracteres")
                .MaximumLength(20).WithMessage("Sua Senha deve ter no máximo 20 caracteres")
                .Must(password => password.ContainsUppercase()).WithMessage("Sua Senha deve conter pelo menos uma letra maiúscula")
                .Must(password => password.ContainsLowercase()).WithMessage("Sua Senha deve conter pelo menos uma letra minúscula")
                .Must(password => password.ContainsNumber()).WithMessage("Sua Senha deve conter pelo menos um número")
                .Must(password => password.ContainsSpecialCharacter()).WithMessage("Sua senha deve conter pelo menos um caractere especial");
        }
    }
}
