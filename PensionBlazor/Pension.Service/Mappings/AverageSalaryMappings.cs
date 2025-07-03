
using Pension.Data.Contracts.DAO;
using Pension.Service.Contracts.Objects;

namespace Pension.Service.Mappings
{
    public static class AverageSalaryMappings
    {
        public static AverageSalaryDto? Map(this AverageSalaryDao input)
        {
            return input == null
            ? null
                : new AverageSalaryDto()
                {
                    AverageSalaryId = input.AverageSalaryId,
                    SalaryYear = input.SalaryYear,
                    SalaryMonth = input.SalaryMonth,
                    Salary = input.Salary
                };
        }


        public static IEnumerable<AverageSalaryDto> Map(this IEnumerable<AverageSalaryDao> input) => input?.Select(i => i.Map()).ToList();
       
        public static AverageSalaryDao? ToEntity(this AverageSalaryDto input)
        {
            return input == null
                ? null
                : new AverageSalaryDao()
                {
                    AverageSalaryId = input.AverageSalaryId,
                    SalaryYear = input.SalaryYear,
                    SalaryMonth = input.SalaryMonth,
                    Salary = input.Salary
                };
        }
        public static IEnumerable<AverageSalaryDao> ToEntity(this IEnumerable<AverageSalaryDto> input) => input?.Select(i => i.ToEntity()).ToList();
    }
}
