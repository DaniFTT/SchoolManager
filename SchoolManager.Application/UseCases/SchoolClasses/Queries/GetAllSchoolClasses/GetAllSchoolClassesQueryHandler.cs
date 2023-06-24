using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Queries.GetAllStudents;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Queries.GetAllSchoolClasses
{
    public sealed class GetAllSchoolClassesQueryHandler : IRequestHandler<GetAllSchoolClassesQuery, Result<IReadOnlyList<SchoolClass>>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public GetAllSchoolClassesQueryHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<Result<IReadOnlyList<SchoolClass>>> Handle(GetAllSchoolClassesQuery query,
            CancellationToken cancellationToken)
        {
            var allSchoolClasses = await _schoolClassRepository.GetAllAsync() as IReadOnlyList<SchoolClass>;

            return Result.Success(allSchoolClasses!);
        }
    }
}
