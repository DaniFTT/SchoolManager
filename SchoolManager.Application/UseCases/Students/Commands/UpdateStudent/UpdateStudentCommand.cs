using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.Students.Commands.UpdateStudent
{
    public sealed record UpdateStudentCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public UpdateStudentCommand() { }

        public UpdateStudentCommand(int id, string name, string user, string password)
        {
            Id = id;
            Name = name;
            User = user;
            Password = password;
        }
    }
}
