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
    public class ExpenseService : ServiceBase, IExpenseService
    {
        public ExpenseService(BudgetTrackerContext context) : base(context)
        { }

        public async Task<IActionResult> GetAll(GetExpensesRequest request)
        {
            var expenses = await _context.Expenses.Where(i => !i.IsDeleted && i.UserId == request.UserId &&
                i.TimeStamp.Month == request.Date.Month && i.TimeStamp.Year == request.Date.Year).Include(i=> i.Currency).ToListAsync();
            var expensesDto = expenses.Select(row => ConvertToVM(row));
            return Success(expensesDto);
        }

        public async Task<IActionResult> Add(AddExpenseRequest request)
        {
            var expense = new Expense()
            {
                CategoryId = request.CategoryId,
                UserId = request.UserId,
                Amount = request.Amount,
                CurrencyId = request.CurrencyId
            };
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            var addedExpense = _context.Expenses.Where(i => i.Id == expense.Id).Include(i => i.Currency).FirstOrDefault();

            return Success(ConvertToVM(addedExpense));
        }

        public async Task<IActionResult> Edit(EditExpenseRequest request)
        {
            var expense = _context.Expenses.Where(i => i.Id == request.ExpenseId).Include(i => i.Currency).FirstOrDefault();
            if (expense == null)
                return Failure();
            expense.Amount = request.Amount;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(expense));
        }

        public async Task<IActionResult> Delete(DeleteExpenseRequest request)
        {
            var expense = _context.Expenses.Where(i => i.Id == request.ExpenseId).FirstOrDefault();
            expense.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Success();
        }

        private ExpenseVM ConvertToVM(Expense expense)
        {
            var dupa = new ExpenseVM()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Currency = new CurrencyVM()
                {
                    ShortName = expense.Currency.ShortName
                }
            };
            return dupa;
        }

    }
}
