
using Pension.Service.Contracts.Objects;

namespace Pension.Service.Contracts.Interfaces
{
    public interface IPersonSalaryService
    {
        Task<List<PersonSalaryDto>> GetAllAsync();
        Task<List<PersonSalaryDto>> GetByPersonAsync(int userLoginId);
        Task<string> SavePersonSalaryAsync(int userLoginId, PaymentData jsonSalaries);
        Task<string> UpdatePersonSalaryAsync(int userLoginId, List<PersonSalaryDto> salaries);
        Task<string> UpdateCustomSalaryAsync(int userLoginId, List<PersonSalaryDto> salaries);
        Task<List<PersonSalaryDto>> GetCustomByPersonAsync(int userLoginId);
   }
}
