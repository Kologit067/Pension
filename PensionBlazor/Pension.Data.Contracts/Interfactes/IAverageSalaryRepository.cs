using Pension.Data.Contracts.DAO;

namespace Pension.Data.Contracts.Interfactes
{
    public interface IAverageSalaryRepository
    {
        Task<List<AverageSalaryDao>> GetAllAsync();
    }
}
