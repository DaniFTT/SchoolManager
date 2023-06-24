using Dapper;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Infrastructure.Repositories
{
    public class SchoolClassRepository : BaseRepository<SchoolClass>, ISchoolClassRepository
    {
        public override string TableName => "turma";

        public SchoolClassRepository(DapperContext context) : base(context) { }

        public override async Task<bool> AddAsync(SchoolClass student)
        {
            var sqlQuery = $@"
                INSERT INTO {TableName} (curso_id, turma, ano)
                OUTPUT INSERTED.id
                VALUES (@CourseId, @ClassName, @Year)";

            return await _context.InsertAsync(sqlQuery, student);
        }

        public override async Task<bool> UpdateAsync(SchoolClass student)
        {
            var sqlQuery = $@"
                UPDATE {TableName} 
                SET 
                    curso_id = @CourseId, 
                    turma = @ClassName, 
                    ano = @Year 
                WHERE id = @Id";

            return await _context.UpdateAsync(sqlQuery, student);
        }

        public override async Task<SchoolClass> GetByIdAsync(int id)
        {
            var sqlQuery = $@"
                SELECT [id],
                    curso_id AS [CourseId], 
                    turma AS [ClassName], 
                    ano AS [Year] 
                FROM {TableName} 
                WHERE id = @id";

            return await _context.GetByIdAsync<SchoolClass>(sqlQuery, id);
        }

        public override async Task<IEnumerable<SchoolClass>> GetAllAsync()
        {
            var sqlQuery = $@"
                SELECT [id],
                    curso_id AS [CourseId], 
                    turma AS [ClassName], 
                    ano AS [Year] 
                FROM {TableName}";

            return await _context.GetAllAsync<SchoolClass>(sqlQuery);
        }

        public async Task<bool> SchoolClassExistsByName(string name)
        {
            var sqlQuery = $@"
                SELECT [id] FROM {TableName} WHERE turma = @name;
            ";

            return (await _context.CreateConnection().QueryFirstOrDefaultAsync<int>(sqlQuery, new { name })) > 0;
        }

        public async Task<bool> AddStudentToClass(int classId, int studentId)
        {
            var sqlQuery = $@"
                INSERT INTO aluno_turma (turma_id, aluno_id)
                VALUES (@classId, @studentId)";

            var result = await _context.CreateConnection().ExecuteAsync(sqlQuery, new { classId, studentId });

            return result > 0;
        }

        public async Task<bool> RemoveStudentFromClass(int classId, int studentId)
        {
            var sqlQuery = $@"
                DELETE FROM aluno_turma 
                WHERE turma_id = @classId
                AND aluno_id = @studentId";

            return await _context.CreateConnection().ExecuteAsync(sqlQuery, new { classId, studentId }) > 0;
        }
    }
}
