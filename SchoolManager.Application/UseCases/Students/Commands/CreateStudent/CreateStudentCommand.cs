using Ardalis.Result;
using MediatR;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.CreateStudent
{
    public sealed record CreateStudentCommand : IRequest<Result<Student>>
    {
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public CreateStudentCommand() { }

        public CreateStudentCommand(string name, string user, string password)
        {
            Name = name;
            User = user;
            Password = password;
        }

        public Student ToDomain()
        {
            return new Student(Name!, User!, Password!);
        }
    }
}
