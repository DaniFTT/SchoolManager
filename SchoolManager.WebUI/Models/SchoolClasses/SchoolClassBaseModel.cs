namespace SchoolManager.WebUI.Models.SchoolClasses
{
    public class SchoolClassBaseModel
    {
        public int? CourseId { get; set; }
        public string? ClassName { get; set; }
        public int? Year { get; set; }

        public SchoolClassBaseModel() { }
        public SchoolClassBaseModel(int? courseId, string className, int? year)
        {
            CourseId = courseId;
            ClassName = className;
            Year = year;
        }
    }
}
