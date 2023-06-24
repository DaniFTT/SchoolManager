using SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolManager.WebAPI.Models.ShoolClassModels
{
    public sealed record CreateSchoolClassRequest
    {
        public int CourseId { get; set; }
        public string? ClassName { get; set; }
        public int Year { get; set; }

        public CreateSchoolClassCommand ToCommand()
        {
            return new CreateSchoolClassCommand(CourseId, ClassName!, Year);
        }
    }
}
