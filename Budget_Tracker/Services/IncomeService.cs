using Budget_Tracker.Database;
using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Budget_Tracker.VievModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{
    public class IncomeService : ServiceBase, IIncomeService
    {
        public IncomeService(BudgetTrackerContext context, IJwtService jwtService) : base(context, jwtService)
        { }

        public async Task<IActionResult> GetAll(DateTime date)
        {
            var userId = _jwtService.GetUserId();
            var incomes = await _context.Incomes.Where(i => !i.IsDeleted && i.UserId == userId &&
                i.TimeStamp.Month == date.Month && i.TimeStamp.Year == date.Year)
                .Include(i => i.Currency).Include(i => i.Category).ToListAsync();
            var incomesDto = incomes.Select(row => ConvertToVM(row));
            return Success(incomesDto);
        }

        public async Task<IActionResult> Add(AddIncomeRequest request)
        {
            var userId = _jwtService.GetUserId();
            if (request.Amount < 0)
                return Failure();
            var income = new Income()
            {
                CategoryId = request.CategoryId,
                UserId = userId,
                Amount = request.Amount,
                CurrencyId = request.CurrencyId
            };
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            var addedIncomes = _context.Incomes.Where(i => i.Id == income.Id)
                .Include(i => i.Currency).Include(i => i.Category).FirstOrDefault();

            return Success(ConvertToVM(addedIncomes));
        }

        public async Task<IActionResult> Edit(EditIncomeRequest request)
        {
            var income = _context.Incomes.Where(i => i.Id == request.IncomeId)
                .Include(i => i.Currency).Include(i => i.Category).FirstOrDefault();
            if (income == null)
                return Failure();
            income.Amount = request.Amount;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(income));
        }

        public async Task<IActionResult> Delete(DeleteIncomeRequest request)
        {
            var income = _context.Incomes.Where(i => i.Id == request.IncomeId).FirstOrDefault();
            income.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Success();
        }

        private IncomeVM ConvertToVM(Income income) => new IncomeVM()
        {
            Id = income.Id,
            Amount = income.Amount,
            Currency = new CurrencyVM()
            {
                ShortName = income.Currency.ShortName
            },
            TimeStamp = income.TimeStamp,
            CategoryName = income.Category.Name
        };
    }
}
