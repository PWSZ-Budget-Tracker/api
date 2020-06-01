using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IIncomeService
    {
        public Task<IActionResult> GetAll(DateTime date);
        public Task<IActionResult> Add(AddIncomeRequest request);
        public Task<IActionResult> Edit(EditIncomeRequest request);
        public Task<IActionResult> Delete(DeleteIncomeRequest request);
    }
}
