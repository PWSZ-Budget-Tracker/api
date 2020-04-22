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
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(BudgetTrackerContext context) : base(context)
        {}

        public async Task<IActionResult> GetAll(GetCategoriesRequest request)
        {
            var categories = await _context.Categories.Where(i => !i.IsDeleted &&
                (i.IsDefault || i.UserId == request.UserId) && i.Type == request.Type).ToListAsync();
            var categoriesDto = categories.Select(row => ConvertToVM(row));
            return Success(categoriesDto);
        }

        public async Task<IActionResult> Add(AddCategoryRequest request)
        {
            var category = new Category()
            {
                Name = request.Name,
                Type = request.Type,
                UserId = request.UserId
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(category));
        }

        public async Task<IActionResult> Edit(EditCategoryRequest request)
        {
            var category = _context.Categories.Where(i => i.Id == request.CategoryId).FirstOrDefault();
            if (category == null)
                return Failure();
            if (category.IsDefault)
                return Failure();
            category.Name = request.Name;
            await _context.SaveChangesAsync();
            return Success(ConvertToVM(category));
        }

        public async Task<IActionResult> Delete(DeleteCategoryRequest request)
        {
            var category = _context.Categories.Where(i => i.Id == request.CategoryId).FirstOrDefault();
            if (category.IsDefault)
                return Failure();
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Success();
        }

        private CategoryVM ConvertToVM(Category category) => new CategoryVM() { Id = category.Id, Name = category.Name, IsDefault = category.IsDefault };
    }
}
