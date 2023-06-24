using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass
{
    public sealed record CreateSchoolClassCommand : IRequest<Result<SchoolClass>>
    {
        public int CourseId { get; set; }
        public string? ClassName { get; set; }
        public int Year { get; set; }

        public CreateSchoolClassCommand() { }

        public CreateSchoolClassCommand(int courseId, string className, int year)
        {
            CourseId = courseId;
            ClassName = className;
            Year = year;
        }

        public SchoolClass ToDomain()
        {
            return new SchoolClass(CourseId, ClassName!, Year);
        }
    }
}
