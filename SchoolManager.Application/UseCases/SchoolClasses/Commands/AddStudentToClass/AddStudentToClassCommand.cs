using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.AddStudentToClass
{
    public sealed record AddStudentToClassCommand(int classId, int studentId) : IRequest<Result>;
}
