using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.InactivateStudent
{
    public sealed record RemoveStudentCommand(int id) : IRequest<Result>;
}
