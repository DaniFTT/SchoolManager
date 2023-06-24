using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Domain.Contratcts.Infrastructure.Repositories
{
    public interface ISchoolClassRepository : IRepository<SchoolClass>
    {
        Task<bool> SchoolClassExistsByName(string name);
        Task<bool> AddStudentToClass(int classId, int studentId);
        Task<bool> RemoveStudentFromClass(int classId, int studentId);
    }
}
