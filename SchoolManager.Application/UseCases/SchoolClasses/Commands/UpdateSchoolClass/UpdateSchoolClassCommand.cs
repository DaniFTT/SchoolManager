using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.UpdateSchoolClass
{
    public sealed record UpdateSchoolClassCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? ClassName { get; set; }
        public int Year { get; set; }

        public UpdateSchoolClassCommand() { }

        public UpdateSchoolClassCommand(int id, int courseId, string className, int year)
        {
            Id = id;
            CourseId = courseId;
            ClassName = className;
            Year = year;
        }
    }
}
