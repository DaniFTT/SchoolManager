using SchoolManager.SharedKernel;
using SchoolManager.SharedKernel.Extesions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Domain.Entities
{
    public class Student : Entity
    {
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public Student() : base() { }

        public Student(string name, string user, string password) : base()
        {
            Name = name;
            User = user;    
            Password = password.ToHash();
        }

        public void UpdateStudent(string? name, string? user, string? password)
        {
            Name = name;
            User = user;
            Password = password!.ToHash();
        }
    }
}
