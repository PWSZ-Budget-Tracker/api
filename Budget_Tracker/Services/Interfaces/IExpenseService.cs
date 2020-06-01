using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IExpenseService
    {
        public Task<IActionResult> GetAll(DateTime date);
        public Task<IActionResult> Add(AddExpenseRequest request);
        public Task<IActionResult> Edit(EditExpenseRequest request);
        public Task<IActionResult> Delete(DeleteExpenseRequest request);
    }
}
