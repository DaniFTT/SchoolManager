using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Domain.Contratcts.Infrastructure.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudentsByClassAsync(int classId);
        Task<Student> GetStudentByClassAsync(int classId, int studentId);
    }
}
