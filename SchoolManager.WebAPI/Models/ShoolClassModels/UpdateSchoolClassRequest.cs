using SchoolManager.Application.UseCases.SchoolClasses.Commands.UpdateSchoolClass;

namespace SchoolManager.WebAPI.Models.ShoolClassModels
{
    public sealed record UpdateSchoolClassRequest
    {
        public int CourseId { get; set; }
        public string? ClassName { get; set; }
        public int Year { get; set; }

        public UpdateSchoolClassCommand ToCommand(int id)
        {
            return new UpdateSchoolClassCommand(id, CourseId, ClassName!, Year);
        }
    }
}
