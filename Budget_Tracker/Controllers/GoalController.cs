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
    public class GoalController : BaseController
    {
        private readonly IGoalService _goalService;
        public GoalController(IGoalService goalService)
            : base()
        {
            _goalService = goalService;
        }
        //[Route("")]
        [HttpPost]
        public async Task<IActionResult> GetAll(GetGoalsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.GetAll(request);
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

        [HttpPost]
        public async Task<IActionResult> Edit(EditGoalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.Edit(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteGoalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.Delete(request);
        }

        [HttpPost]
        public async Task<IActionResult> AddAmount(AddAmountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _goalService.AddAmount(request);
        }

        [HttpPost]
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
