using Pension.Data.Contracts.DAO;

namespace Pension.Data.Contracts.Interfactes
{
    public interface IPersonSalaryRepository
    {
        Task<List<PersonSalaryDao>> GetAllAsync();
        Task<List<PersonSalaryDao>> GetByPersonAsync(int userLoginId);
        Task<string> UpdatePersonSalaryAsync(int userLoginId, List<PersonSalaryDao> salaries);
        Task<string> UpdateCustomSalaryAsync(int userLoginId, List<PersonSalaryDao> salaries);
        Task<List<PersonSalaryDao>> GetCustomByPersonAsync(int userLoginId);
    }
}
