using Pension.Service.Contracts.Objects;

namespace Pension.Service.Contracts.Interfaces
{
    public interface IAverageSalaryService
    {
        Task<List<AverageSalaryDto>> GetAllAsync();
    }
}
