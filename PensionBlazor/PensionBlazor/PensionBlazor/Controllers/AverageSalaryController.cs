using Microsoft.AspNetCore.Mvc;
using Pension.Service.Contracts.Interfaces;

namespace PensionBlazor.Controllers
{
    public class AverageSalaryController : Controller
    {
        private readonly IAverageSalaryService _averageSalaryService;
        public AverageSalaryController(IAverageSalaryService averageSalaryService)
        {
            _averageSalaryService = averageSalaryService;
        }
        [Route("api/AverageSalary/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _averageSalaryService.GetAllAsync();
            return Json(result);
        }
    }
}
