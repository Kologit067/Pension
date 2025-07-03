
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Pension.Data.Contracts;
using Pension.Data.Contracts.DAO;
using Pension.Data.Contracts.Interfactes;

namespace Pension.Data.Implementation
{
    public class AverageSalaryRepository : IAverageSalaryRepository
    {
        string connectionString;
        public AverageSalaryRepository(IOptions<ConnectionStrings> options) 
        {
            connectionString = options.Value.PensionDb;
        }
        public async Task<List<AverageSalaryDao>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return (await db.QueryAsync<AverageSalaryDao>("SELECT [AverageSalaryId],[SalaryYear],[SalaryMonth],[Salary] FROM [dbo].[AverageSalary]")).ToList();

            }
        }
    }
}
