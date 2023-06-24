using SchoolManager.SharedKernel;
using SchoolManager.SharedKernel.Extesions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManager.Domain.Entities
{
    public class SchoolClass : Entity
    {
        public int CourseId { get; set; }
        public string? ClassName { get; set; }
        public int Year { get; set; }

        public SchoolClass() : base() { }

        public SchoolClass(int courseId, string className, int year) : base()
        {
            CourseId = courseId;
            ClassName = className;
            Year = year;
        }

        public void UpdateSchoolClass(int courseId, string className, int year)
        {
            CourseId = courseId;
            ClassName = className;
            Year = year;
        }
    }
}
