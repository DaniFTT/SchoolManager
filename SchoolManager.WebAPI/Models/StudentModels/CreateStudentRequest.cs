using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Domain.Entities;
using SchoolManager.WebAPI.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace SchoolManager.WebAPI.Models.StudentModels
{
    public sealed record CreateStudentRequest
    {
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public CreateStudentCommand ToCommand()
        {
            return new CreateStudentCommand(Name!, User!, Password!);
        }
    }
}
