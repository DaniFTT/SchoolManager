using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.UpdateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Queries.GetStudentById
{
    public sealed class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<Student>>
    {

        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository repository)
        {
            _studentRepository = repository;
        }

        public async Task<Result<Student>> Handle(GetStudentByIdQuery query, 
            CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(query.id);

            return student is not null ? student : Result.NotFound("Aluno não encontrado!");
        }
    }
}

