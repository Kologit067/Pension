using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PensionImport
{
    public class ImportSalary
    {

        public void Insert(List<PersonSalary> salaryList)
        {
            using (IDbConnection db = new SqlConnection("Data Source=LAPTOP-8098K11E\\SQLEXPRESS;Initial Catalog=Pension;Integrated Security=true;TrustServerCertificate=True"))
            {
                var sqlQuery = "INSERT INTO [PersonSalary] ([SalaryYear],[SalaryMonth],[SalaryForPens],[UserLoginId]) VALUES(@SalaryYear,@SalaryMonth,@SalaryForPens,@UserLoginId)";
                foreach (PersonSalary salary in salaryList)
                    db.Execute(sqlQuery, salary);

            }
        }
        public void InsertAvarage(List<AverageSalary> salaryList)
        {
            using (IDbConnection db = new SqlConnection("Data Source=LAPTOP-8098K11E\\SQLEXPRESS;Initial Catalog=Pension;Integrated Security=true;TrustServerCertificate=True"))
            {
                var sqlQuery = "INSERT INTO [AverageSalary] ([SalaryYear],[SalaryMonth],[Salary]) VALUES(@SalaryYear,@SalaryMonth,@Salary)";
                foreach (AverageSalary salary in salaryList)
                    db.Execute(sqlQuery, salary);

            }
        }
    }
}
