
namespace Pension.Data.Contracts.DAO
{
    public class AverageSalaryDao
    {
        public int AverageSalaryId { get; set; }
        public int SalaryYear { get; set; }
        public int SalaryMonth { get; set; }
        public decimal Salary { get; set; }
    }
}
