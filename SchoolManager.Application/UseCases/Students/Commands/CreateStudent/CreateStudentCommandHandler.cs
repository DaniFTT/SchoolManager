using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using MediatR;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.CreateStudent
{
    public sealed class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<Student>> Handle(CreateStudentCommand createStudentCommand, 
            CancellationToken cancellationToken)
        {       
            var student = createStudentCommand.ToDomain();

            var operationSucceded = await _studentRepository.AddAsync(student);

            return operationSucceded ? Result.Success(student) : Result.Error(GlobaErrors.BaseError);
        }
    }
}
