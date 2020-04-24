﻿using Budget_Tracker.Database;
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
    public class IncomeService : ServiceBase, IIncomeService
    {
       

        public IncomeService(BudgetTrackerContext context) : base(context)
        { }

        public async Task<IActionResult> GetAll(GetIncomesRequest request)
        {
            var incomes = await _context.Incomes.Where(i => !i.IsDeleted && i.UserId == request.UserId &&
                i.TimeStamp.Month == request.Date.Month && i.TimeStamp.Year == request.Date.Year).Include(i => i.Currency).ToListAsync();
            var incomesDto = incomes.Select(row => ConvertToVM(row));
            return Success(incomesDto);
        }

        public async Task<IActionResult> Add(AddIncomeRequest request)
        {
            if (request.Amount < 0)
                return Failure();
            var income = new Income()
            {
                CategoryId = request.CategoryId,
                UserId = request.UserId,
                Amount = request.Amount,
                CurrencyId = request.CurrencyId
            };
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            var addedIncomes = _context.Incomes.Where(i => i.Id == income.Id).Include(i => i.Currency).FirstOrDefault();

            return Success(ConvertToVM(addedIncomes));
        }

        public async Task<IActionResult> Edit(EditIncomeRequest request)
        {
            var income = _context.Incomes.Where(i => i.Id == request.IncomeId).Include(i => i.Currency).FirstOrDefault();
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
            }
        };
    }
}
