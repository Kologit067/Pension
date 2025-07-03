

namespace Pension.Service.Contracts.Objects
{
    public class AverageSalaryDto
    {
        public int AverageSalaryId { get; set; }
        public int SalaryYear { get; set; }
        public int SalaryMonth { get; set; }
        public decimal Salary { get; set; }
    }
}
