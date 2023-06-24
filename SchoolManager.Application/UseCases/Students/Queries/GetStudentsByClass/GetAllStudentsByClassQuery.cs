using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Queries.GetStudentsByClass
{
    public sealed record GetAllStudentsByClassQuery(int classId) : IRequest<Result<IReadOnlyList<Student>>>;
}
