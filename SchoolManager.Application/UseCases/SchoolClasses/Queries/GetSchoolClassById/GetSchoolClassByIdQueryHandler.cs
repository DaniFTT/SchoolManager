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

namespace SchoolManager.Application.UseCases.SchoolClasses.Queries.GetSchoolClassById
{
    public sealed class GetSchoolClassByIdQueryHandler : IRequestHandler<GetSchoolClassByIdQuery, Result<SchoolClass>>
    {

        private readonly ISchoolClassRepository _schoolClassRepository;

        public GetSchoolClassByIdQueryHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<Result<SchoolClass>> Handle(GetSchoolClassByIdQuery query,
            CancellationToken cancellationToken)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(query.id);

            return schoolClass is not null ? schoolClass : Result.NotFound("Turma não encontrada!");
        }
    }
}
