using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class IncomeController :BaseController
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
            : base()
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody]GetIncomesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _incomeService.GetAll(request);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddIncomeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _incomeService.Add(request);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditIncomeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _incomeService.Edit(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteIncomeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _incomeService.Delete(request);
        }
    }
}
