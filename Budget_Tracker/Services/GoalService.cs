using Budget_Tracker.Database;
using Budget_Tracker.Enums;
using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Budget_Tracker.VievModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{
    public class GoalService : ServiceBase, IGoalService
    {
        public GoalService(BudgetTrackerContext context) : base(context)
        { }

        public async Task<IActionResult> GetAll(GetGoalsRequest request)
        {
            var goals = await _context.Goals.Where(i => !i.IsDeleted && i.UserId == request.UserId).Include(i => i.Currency).ToListAsync();
            var goalsDto = goals.Select(row => ConvertToVM(row));
            return Success(goalsDto);
        }

        public async Task<IActionResult> Add(AddGoalRequest request)
        {
            if (request.GoalAmount < 0)
                return Failure();
            var goal = new Goal()
            {
                Name = request.Name,
                UserId = request.UserId,
                GoalAmount = request.GoalAmount,
                CurrencyId = request.CurrencyId
            };
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            var addedGoal = _context.Goals.Where(i => i.Id == goal.Id).Include(i => i.Currency).FirstOrDefault();

            return Success(ConvertToVM(addedGoal));
        }

        public async Task<IActionResult> Edit(EditGoalRequest request)
        {
            var goal = _context.Goals.Where(i => i.Id == request.GoalId).Include(i => i.Currency).FirstOrDefault();
            if (goal == null)
                return Failure();
            goal.GoalAmount = request.GoalAmount;
            goal.Name = request.Name;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(goal));
        }

        public async Task<IActionResult> Delete(DeleteGoalRequest request)
        {
            var goal = _context.Goals.Where(i => i.Id == request.GoalId).FirstOrDefault();
            goal.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Success();
        }

        public async Task<IActionResult> AddAmount(AddAmountRequest request)
        {
            if (request.Amount < 0)
                return Failure();
            var goal = _context.Goals.Where(i => i.Id == request.GoalId).Include(i => i.Currency).FirstOrDefault();
            if (goal == null)
                return Failure();
            goal.Amount += request.Amount;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(goal));
        }

        public async Task<IActionResult> DeleteAmount(DeleteAmountRequest request)
        {
            if (request.Amount < 0)
                return Failure();
            var goal = _context.Goals.Where(i => i.Id == request.GoalId).Include(i => i.Currency).FirstOrDefault();
            if (goal == null)
                return Failure();
            goal.Amount -= request.Amount;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(goal));
        }

        private GoalVM ConvertToVM(Goal goal) => new GoalVM()
        {
            Id = goal.Id,
            Name = goal.Name,
            Amount = goal.Amount,
            GoalAmount = goal.GoalAmount,
            Currency = new CurrencyVM()
            {
                ShortName = goal.Currency.ShortName
            }
        };
    }
}
