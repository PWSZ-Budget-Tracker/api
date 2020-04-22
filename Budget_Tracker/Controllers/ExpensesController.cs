using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //[Route("")]
        [HttpPost]
        public async Task<IActionResult> GetAll(GetExpensesRequest request)
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

        [HttpPost]
        public async Task<IActionResult> Edit(EditExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _expenseService.Edit(request);
        }

        [HttpPost]
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
