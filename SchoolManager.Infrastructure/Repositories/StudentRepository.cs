using Dapper;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Infrastructure.DbContext;
using SchoolManager.SharedKernel.Extesions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManager.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public override string TableName => "aluno";

        public StudentRepository(DapperContext context) : base(context) { }

        public override async Task<bool> AddAsync(Student student)
        {
            var sqlQuery =  $@"
                INSERT INTO {TableName} (nome, usuario, senha)
                OUTPUT INSERTED.id
                VALUES (@Name, @User, @Password)";

            return await _context.InsertAsync(sqlQuery, student);
        }
        
        public override async Task<bool> UpdateAsync(Student student)
        {
            var sqlQuery = $@"
                UPDATE {TableName} 
                SET 
                    nome = @Name, 
                    usuario = @User, 
                    senha = @Password 
                WHERE id = @Id";

            return await _context.UpdateAsync(sqlQuery, student);
        }

        public override async Task<Student> GetByIdAsync(int id)
        {
            var sqlQuery = $@"
                SELECT [id],
                    nome AS [Name], 
                    usuario AS [User], 
                    senha AS [Password] 
                FROM {TableName} 
                WHERE id = @id";

            return await _context.GetByIdAsync<Student>(sqlQuery, id);
        }

        public override async Task<IEnumerable<Student>> GetAllAsync()
        {
            var sqlQuery = $@"
                SELECT [id],
                    nome AS [Name], 
                    usuario AS [User], 
                    senha AS [Password] 
                FROM {TableName}";

            return await _context.GetAllAsync<Student>(sqlQuery);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByClassAsync(int classId)
        {
            var sqlQuery = $@"
                SELECT  
                    aluno.id as [Id],
                    aluno.nome AS [Name], 
                    aluno.usuario AS [User], 
                    aluno.senha AS [Password] 
                FROM aluno_turma
                JOIN aluno ON aluno.id = aluno_turma.aluno_id
                JOIN turma ON turma.id = aluno_turma.turma_id
                WHERE turma.id = @classId
            ";

            return await _context.CreateConnection().QueryAsync<Student>(sqlQuery, new { classId });
        }

        public async Task<Student> GetStudentByClassAsync(int classId, int studentId)
        {
            var sqlQuery = $@"
                SELECT  
                    aluno.id as [Id],
                    aluno.nome AS [Name], 
                    aluno.usuario AS [User], 
                    aluno.senha AS [Password] 
                FROM aluno_turma
                JOIN aluno ON aluno.id = aluno_turma.aluno_id
                JOIN turma ON turma.id = aluno_turma.turma_id
                WHERE turma.id = @classId
                AND aluno.id = @studentId
            ";

            return await _context.CreateConnection().QueryFirstOrDefaultAsync<Student>(sqlQuery, new { classId, studentId });
        }
    }
}
