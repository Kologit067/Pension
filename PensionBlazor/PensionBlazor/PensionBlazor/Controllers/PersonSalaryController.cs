using Microsoft.AspNetCore.Mvc;
using Pension.Service.Contracts.Interfaces;
using Pension.Service.Contracts.Objects;

namespace PensionBlazor.Controllers
{
    [Route("api/PersonSalary")]
    public class PersonSalaryController : Controller
    {
        private readonly IPersonSalaryService _personSalaryService;
        public PersonSalaryController(IPersonSalaryService averageSalaryService)
        {
            _personSalaryService = averageSalaryService;
        }
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personSalaryService.GetAllAsync();
            return Json(result);
        }
        [Route("GetByPerson/{id}")]
        public async Task<IActionResult> GetByPerson(int id)
        {
            var result = await _personSalaryService.GetByPersonAsync(id);
            return Json(result);
        }
        [Route("GetCustomByPerson/{id}")]
        public async Task<IActionResult> GetCustomByPerson(int id)
        {
            var result = await _personSalaryService.GetCustomByPersonAsync(id);
            return Json(result);
        }
        [HttpPost]
        [Route("SavePersonSalary/{id}")]
        public async Task<IActionResult> SavePersonSalaryAsync(int id, [FromBody] PaymentData jsonSalaries)
        {
            var result = await _personSalaryService.SavePersonSalaryAsync(id, jsonSalaries);
            return Json(result);
        }
        [HttpPost]
        [Route("UpdatePersonSalary/{id}")]
        public async Task<IActionResult> UpdatePersonSalaryAsync(int id, [FromBody] List<PersonSalaryDto> jsonSalaries)
        {
            var result = await _personSalaryService.UpdatePersonSalaryAsync(id, jsonSalaries);
            return Json(result);
        }
        [HttpPost]
        [Route("UpdateCustomSalary/{id}")]
        public async Task<IActionResult> UpdateCustomSalaryAsync(int id, [FromBody] List<PersonSalaryDto> jsonSalaries)
        {
            var result = await _personSalaryService.UpdateCustomSalaryAsync(id, jsonSalaries);
            return Json(result);
        }
    }
}
