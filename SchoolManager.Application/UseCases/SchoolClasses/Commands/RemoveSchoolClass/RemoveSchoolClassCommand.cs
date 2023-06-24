using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveSchoolClass
{
    public sealed record RemoveSchoolClassCommand(int id) : IRequest<Result>;
}
