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
    public class ExpensesController : BaseController
    {
        private readonly IExpenseService _expenseService;
        public ExpensesController(IExpenseService expenseService)
            : base()
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody]GetExpensesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _expenseService.GetAll(request);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _expenseService.Add(request);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _expenseService.Edit(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _expenseService.Delete(request);
        }
    }
}
