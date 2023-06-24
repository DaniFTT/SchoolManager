using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Queries.GetStudentById;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Queries.GetAllStudents
{
    public sealed class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, Result<IReadOnlyList<Student>>>
    {

        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository repository)
        {
            _studentRepository = repository;
        }

        public async Task<Result<IReadOnlyList<Student>>> Handle(GetAllStudentsQuery query, 
            CancellationToken cancellationToken)
        {
            var allStudents = await _studentRepository.GetAllAsync() as IReadOnlyList<Student>;

            return Result.Success(allStudents!);
        }
    }
}
