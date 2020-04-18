using Budget_Tracker.Database;
using Budget_Tracker.Enums;
using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(BudgetTrackerContext context) : base(context)
        {}

        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.Where(i => !i.IsDeleted).ToListAsync();
            return Success(categories);
        }

        public async Task<IActionResult> Add(AddCategoryRequest request)
        {
            var category = new Category()
            {
                Name = request.Name,
                Type = request.Type
            };
            var result =  _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Success(category);
        }

        public async Task<IActionResult> Edit(EditCategoryRequest request)
        {
            var category = _context.Categories.Where(i => i.Id == request.CategoryId).FirstOrDefault();
            if (category == null)
                return Failure();
            category.Name = request.Name;
            await _context.SaveChangesAsync();
            return Success(category);
        }

        public async Task<IActionResult> Delete(DeleteCategoryRequest request)
        {
            var category = _context.Categories.Where(i => i.Id == request.CategoryId).FirstOrDefault();
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Success();
        }
    }
}
