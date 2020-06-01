using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GoalController : BaseController
    {
        private readonly IGoalService _goalService;
        public GoalController(IGoalService goalService)
            : base()
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGoalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.Add(request);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditGoalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.Edit(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteGoalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.Delete(request);
        }

        [HttpPut]
        public async Task<IActionResult> AddAmount(AddAmountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.AddAmount(request);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAmount(DeleteAmountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.DeleteAmount(request);
        }
    }
}
