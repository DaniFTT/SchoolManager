using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Queries.GetAllStudents
{
    public sealed record GetAllStudentsQuery() : IRequest<Result<IReadOnlyList<Student>>>;
}
