using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.UpdateStudent
{
    public sealed class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(UpdateStudentCommand updateStudentCommand, 
            CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(updateStudentCommand.Id);
            if(student is null)
                return Result.NotFound("Aluno não encontrado!");

            student.UpdateStudent(updateStudentCommand.Name, updateStudentCommand.User, updateStudentCommand.Password);

            var operationSucceded = await _studentRepository.UpdateAsync(student);

            return operationSucceded ? Result.Success() : Result.Error(GlobaErrors.BaseError);
        }
    }
}
