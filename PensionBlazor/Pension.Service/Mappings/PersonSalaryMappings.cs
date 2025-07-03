
using Pension.Data.Contracts.DAO;
using Pension.Service.Contracts.Objects;

namespace Pension.Service.Mappings
{
     public static class PersonSalaryMappings
    {
        public static PersonSalaryDto? Map(this PersonSalaryDao input)
        {
            return input == null
            ? null
                : new PersonSalaryDto()
                {
                    PersonSalaryId = input.PersonSalaryId,
                    SalaryYear = input.SalaryYear,
                    SalaryMonth = input.SalaryMonth,
                    SalaryForPens = input.SalaryForPens,
                    IsSelected = input.IsSelected,
                    UserLoginId = input.UserLoginId,
                    Email = input.Email
                };
        }


        public static IEnumerable<PersonSalaryDto> Map(this IEnumerable<PersonSalaryDao> input) => input?.Select(i => i.Map()).ToList();

        public static PersonSalaryDao? ToEntity(this PersonSalaryDto input)
        {
            return input == null
                ? null
                : new PersonSalaryDao()
                {
                    PersonSalaryId = input.PersonSalaryId,
                    SalaryYear = input.SalaryYear,
                    SalaryMonth = input.SalaryMonth,
                    SalaryForPens = input.SalaryForPens,
                    IsSelected = input.IsSelected,
                    UserLoginId = input.UserLoginId,
                    Email = input.Email
                };
        }
        public static IEnumerable<PersonSalaryDao> ToEntity(this IEnumerable<PersonSalaryDto> input) => input?.Select(i => i.ToEntity()).ToList();
    }

}
