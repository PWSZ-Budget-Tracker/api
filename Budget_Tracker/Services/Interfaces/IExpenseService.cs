using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IExpenseService
    {
        public Task<IActionResult> GetAll(GetExpensesRequest request);
        public Task<IActionResult> Add(AddExpenseRequest request);
        public Task<IActionResult> Edit(EditExpenseRequest request);
        public Task<IActionResult> Delete(DeleteExpenseRequest request);
    }
}
