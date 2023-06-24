using SchoolManager.Application.UseCases.Students.Commands.UpdateStudent;
using SchoolManager.WebAPI.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace SchoolManager.WebAPI.Models.StudentModels
{
    public sealed record UpdateStudentRequest
    {
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public UpdateStudentCommand ToCommand(int id)
        {
            return new UpdateStudentCommand(id, Name!, User!, Password!);
        }
    }
}
