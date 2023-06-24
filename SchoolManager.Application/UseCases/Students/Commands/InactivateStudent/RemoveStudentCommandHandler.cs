using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Application.UseCases.Students.Commands.UpdateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.InactivateStudent
{
    public sealed class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;

        public RemoveStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(RemoveStudentCommand command, 
            CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(command.id);
            if (student is null)
                return Result.NotFound("Aluno não encontrado!");

            await _studentRepository.RemoveAsync(command.id);

            return Result.Success();
        }
    }
}
