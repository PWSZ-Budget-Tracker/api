using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IGoalService
    {
        public Task<IActionResult> GetAll();
        public Task<IActionResult> Add(AddGoalRequest request);
        public Task<IActionResult> Edit(EditGoalRequest request);
        public Task<IActionResult> Delete(DeleteGoalRequest request);
        public Task<IActionResult> AddAmount(AddAmountRequest request);
        public Task<IActionResult> DeleteAmount(DeleteAmountRequest request);
    }
}
