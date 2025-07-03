using Microsoft.Extensions.Options;
using Dapper;
using Microsoft.Data.SqlClient;
using Pension.Data.Contracts;
using Pension.Data.Contracts.DAO;
using System.Data;
using Pension.Data.Contracts.Interfactes;

namespace Pension.Data.Implementation
{
    public class PersonSalaryRepository : IPersonSalaryRepository
    {
        private readonly string connectionString; // = "Data Source=LAPTOP-8098K11E\\SQLEXPRESS;Initial Catalog=Pension;Integrated Security=true;TrustServerCertificate=True";
        public PersonSalaryRepository(IOptions<ConnectionStrings> options)
        {
            connectionString = options.Value.PensionDb;
        }
        public async Task<List<PersonSalaryDao>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = @$"SELECT [PersonSalaryId],[SalaryYear],[SalaryMonth],[SalaryForPens],ps.[UserLoginId],ul.email,[IsSelected]
                    FROM [dbo].[PersonSalary] as ps
                    INNER JOIN [dbo].[UserLogin] as ul
                    ON ps.UserLoginId = ul.UserLoginId";
                return (await db.QueryAsync<PersonSalaryDao>(query)).ToList();

            }
        }
        public async Task<List<PersonSalaryDao>> GetByPersonAsync(int userLoginId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = @$"SELECT [PersonSalaryId],[SalaryYear],[SalaryMonth],[SalaryForPens],ps.[UserLoginId],ul.email,[IsSelected]
                    FROM [dbo].[PersonSalary] as ps
                    INNER JOIN [dbo].[UserLogin] as ul
                    ON ps.UserLoginId = ul.UserLoginId
                    WHERE ps.UserLoginId = {userLoginId}";
                return (await db.QueryAsync<PersonSalaryDao>(query)).ToList();

            }
        }
        public async Task<List<PersonSalaryDao>> GetCustomByPersonAsync(int userLoginId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = @$"SELECT [CustomPersonSalaryId],[SalaryYear],[SalaryMonth],[SalaryForPens],ps.[UserLoginId],ul.email,[IsSelected]
                    FROM [dbo].[CustomPersonSalary] as ps
                    INNER JOIN [dbo].[UserLogin] as ul
                    ON ps.UserLoginId = ul.UserLoginId
                    WHERE ps.UserLoginId = {userLoginId}";
                return (await db.QueryAsync<PersonSalaryDao>(query)).ToList();

            }
        }
        public async Task<string> UpdatePersonSalaryAsync(int userLoginId, List<PersonSalaryDao> salaries)
        {
            string result = string.Empty;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var dt = CreatePersonSalaryTable(salaries);


                    await db.ExecuteAsync("dbo.addPersonSalary",
                        new
                        {

                            UserLoginId = userLoginId,
                            PersonSalaries = dt.AsTableValuedParameter("dbo.PersonSalaryType")
                        },
                        commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public async Task<string> UpdateCustomSalaryAsync(int userLoginId, List<PersonSalaryDao> salaries)
        {
            string result = string.Empty;
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var dt = CreatePersonSalaryTable(salaries);


                    await db.ExecuteAsync("dbo.addCustomSalary",
                        new
                        {

                            UserLoginId = userLoginId,
                            PersonSalaries = dt.AsTableValuedParameter("dbo.PersonSalaryType")
                        },
                        commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;

        }

        private DataTable CreatePersonSalaryTable(List<PersonSalaryDao> salaries)
        {
            var dt = new DataTable();
            dt.Columns.Add("SalaryYear", typeof(int));
            dt.Columns.Add("SalaryMonth", typeof(int));
            dt.Columns.Add("SalaryForPens", typeof(decimal));
            dt.Columns.Add("IsSelected", typeof(bool));

            foreach (var salary in salaries)
            {
                dt.Rows.Add(salary.SalaryYear, salary.SalaryMonth, salary.SalaryForPens, salary.IsSelected);
            }
            return dt;
        }
    }
}
