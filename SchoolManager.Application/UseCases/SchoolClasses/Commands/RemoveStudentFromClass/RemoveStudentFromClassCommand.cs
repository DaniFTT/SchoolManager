using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveStudentFromClass
{
    public sealed record RemoveStudentFromClassCommand(int classId, int studentId) : IRequest<Result>;
}
