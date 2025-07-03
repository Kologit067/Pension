
using Pension.Data.Contracts.DAO;
using Pension.Data.Contracts.Interfactes;
using Pension.Service.Contracts.Interfaces;
using Pension.Service.Contracts.Objects;
using Pension.Service.Mappings;

namespace Pension.Service.Implementations
{ 
    public class AverageSalaryService : IAverageSalaryService
    {
        private readonly IAverageSalaryRepository _averageSalaryRepository;
        public AverageSalaryService(IAverageSalaryRepository averageSalaryRepository) 
        {
            _averageSalaryRepository = averageSalaryRepository;
        }
        public async Task<List<AverageSalaryDto>> GetAllAsync()
        {
            List<AverageSalaryDao>  result = await _averageSalaryRepository.GetAllAsync();
            return result.Map().ToList();
        }
    }
}
