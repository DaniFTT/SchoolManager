using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Queries.GetAllSchoolClasses
{
    public sealed record GetAllSchoolClassesQuery() : IRequest<Result<IReadOnlyList<SchoolClass>>>;
}
