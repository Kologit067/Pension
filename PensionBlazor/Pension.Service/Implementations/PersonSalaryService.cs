using System.Data;
using Pension.Data.Contracts.DAO;
using Pension.Data.Contracts.Interfactes;
using Pension.Service.Contracts.Interfaces;
using Pension.Service.Contracts.Objects;
using Pension.Service.Mappings;

namespace Pension.Service.Implementations
{
    public class PersonSalaryService : IPersonSalaryService
    {
        private readonly IPersonSalaryRepository _personSalaryRepository;
        public PersonSalaryService(IPersonSalaryRepository personSalaryRepository)
        {
            _personSalaryRepository = personSalaryRepository;
        }
        public async Task<List<PersonSalaryDto>> GetAllAsync()
        {
            List<PersonSalaryDao> result = await _personSalaryRepository.GetAllAsync();
            return result.Map().ToList();
        }
        public async Task<List<PersonSalaryDto>> GetByPersonAsync(int userLoginId)
        {
            List<PersonSalaryDao> result = await _personSalaryRepository.GetByPersonAsync(userLoginId);
            return result.Map().ToList();
        }
        public async Task<List<PersonSalaryDto>> GetCustomByPersonAsync(int userLoginId)
        {
            List<PersonSalaryDao> result = await _personSalaryRepository.GetCustomByPersonAsync(userLoginId);
            return result.Map().ToList();
        }
        public async Task<string> SavePersonSalaryAsync(int userLoginId, PaymentData paymentData)
        {
            List<PersonSalaryDto> salaries = new List<PersonSalaryDto>();
            if (paymentData != null)
            {
                salaries = CreateSalaryList(userLoginId, paymentData);
            }
            return await UpdatePersonSalaryAsync(userLoginId, salaries);
        }
        public async Task<string> UpdatePersonSalaryAsync(int userLoginId, List<PersonSalaryDto> salaries)
        {
            return await _personSalaryRepository.UpdatePersonSalaryAsync(userLoginId, salaries.ToEntity().ToList());
        }
        public async Task<string> UpdateCustomSalaryAsync(int userLoginId, List<PersonSalaryDto> salaries)
        {
            return await _personSalaryRepository.UpdateCustomSalaryAsync(userLoginId, salaries.ToEntity().ToList());
        }

        private static List<PersonSalaryDto> CreateSalaryList(int userLoginId, PaymentData paymentData)
        {
            List<PersonSalaryDto> result = new List<PersonSalaryDto>();
            foreach (var item in paymentData.Items)
            {
                int year = item.Year;
                for (int i = 0; i < item.ForPens.Count; i++)
                {
                    PersonSalaryDto salary = new PersonSalaryDto()
                    {
                        SalaryYear = year,
                        SalaryMonth = i + 1,
                        SalaryForPens = item.ForPens[i],
                        IsSelected = true,
                        UserLoginId = userLoginId
                    };
                    result.Add(salary);
                }
            }
            return result.OrderBy(s => s.SalaryYear).ToList();
        }

    }
}
