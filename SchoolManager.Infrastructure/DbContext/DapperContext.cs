using Dapper;
using Microsoft.Extensions.Options;
using SchoolManager.SharedKernel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using static Dapper.SqlMapper;


namespace SchoolManager.Infrastructure.DbContext
{
    public class DapperContext
    {
        private readonly DapperSettings _dapperSettings;

        public DapperContext(IOptions<DapperSettings> DapperSettings)
        {
            _dapperSettings = DapperSettings.Value;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_dapperSettings.SqlServer);

        public async Task<bool> InsertAsync<T>(string sqlquery, T obj) where T : Entity
        {
            ValidateOperation(sqlquery, DbOperatorsEnum.INSERT);

            using var context = CreateConnection();

            var idResult = await context.QuerySingleAsync<int>(sqlquery, obj);

            obj.Id = idResult;

            return idResult > 0;
        }

        public async Task<bool> UpdateAsync<T>(string sqlquery, T obj) where T : Entity
        {
            ValidateOperation(sqlquery, DbOperatorsEnum.UPDATE);

            using var context = CreateConnection();

            var result = await context.ExecuteAsync(sqlquery, obj);

            return result > 0;
        }

        public async Task<bool> RemoveByIdAsync(string sqlquery, int id)
        {
            ValidateOperation(sqlquery, DbOperatorsEnum.DELETE);

            using var context = CreateConnection();

            var result = await context.ExecuteAsync(sqlquery, new { id });

            return result > 0;
        }

        public async Task<T> GetByIdAsync<T>(string sqlquery, int id) where T : Entity
        {
            ValidateOperation(sqlquery, DbOperatorsEnum.SELECT);

            using var context = CreateConnection();

            var result = await context.QueryFirstOrDefaultAsync<T>(sqlquery, new { id });

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sqlquery) where T : Entity
        {
            ValidateOperation(sqlquery, DbOperatorsEnum.SELECT);

            using var context = CreateConnection();

            var result = await context.QueryAsync<T>(sqlquery);

            return result;
        }

        private static void ValidateOperation(string sqlquery, DbOperatorsEnum dbOperator)
        {
            if(!sqlquery.ReplaceLineEndings(string.Empty).TrimStart().StartsWith(dbOperator.ToString().ToUpperInvariant()) &&
                !sqlquery.ReplaceLineEndings(string.Empty).TrimStart().StartsWith(dbOperator.ToString().ToLowerInvariant()))
            {
                throw new InvalidOperationException("Operação do Banco de Dados Inválida");
            }
        }

    }
}
