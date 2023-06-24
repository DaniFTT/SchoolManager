using Dapper;
using SchoolManager.Domain.Contratcts.Infrastructure;
using SchoolManager.Infrastructure.DbContext;
using SchoolManager.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly DapperContext _context;
        public abstract string TableName { get; }

        public BaseRepository(DapperContext context)
        {
            _context = context;
        }

        public abstract Task<bool> AddAsync(T entity);

        public abstract Task<bool> UpdateAsync(T entity);

        public abstract Task<T> GetByIdAsync(int id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public async Task<bool> RemoveAsync(int id)
        {
            var sqlQuery = $@"
                DELETE FROM {TableName} WHERE id = @id";

            return await _context.RemoveByIdAsync(sqlQuery, id);
        }
    }
}
