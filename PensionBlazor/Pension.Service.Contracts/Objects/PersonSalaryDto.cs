
namespace Pension.Service.Contracts.Objects
{
    public class PersonSalaryDto
    {
        public int PersonSalaryId { get; set; }
        public int SalaryYear { get; set; }
        public int SalaryMonth { get; set; }
        public decimal SalaryForPens { get; set; }
        public bool IsSelected { get; set; }
        public int UserLoginId { get; set; }
        public string Email { get; set; }
    }
}
