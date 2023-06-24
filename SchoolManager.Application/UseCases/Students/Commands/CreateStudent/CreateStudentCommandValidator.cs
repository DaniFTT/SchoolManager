using FluentValidation;
using SchoolManager.SharedKernel.Extesions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.CreateStudent
{
    internal class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(255).WithMessage("O Nome deve conter no máximo 255 caracteres");

            RuleFor(p => p.User)
                .NotEmpty().WithMessage("O Usuário é obrigatório")
                .MaximumLength(45).WithMessage("O Usuário deve conter no máximo 45 caracteres");
        }
    }

    internal class PasswordValidator : AbstractValidator<CreateStudentCommand>
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
