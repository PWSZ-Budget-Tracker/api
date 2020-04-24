using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IIncomeService
    {
        public Task<IActionResult> GetAll(GetIncomesRequest request);
        public Task<IActionResult> Add(AddIncomeRequest request);
        public Task<IActionResult> Edit(EditIncomeRequest request);
        public Task<IActionResult> Delete(DeleteIncomeRequest request);
    }
}
