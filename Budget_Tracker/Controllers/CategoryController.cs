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
    public class CategoryController :BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
            : base()
        {
            _categoryService = categoryService;
        }
        //[Route("")]
        [HttpPost]
        public async Task<IActionResult> GetAll(GetCategoriesRequest request)
        {
                if (!ModelState.IsValid)
                {
                    return Failure();
                }

                return await _categoryService.GetAll(request);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _categoryService.Add(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _categoryService.Edit(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _categoryService.Delete(request);
        }
    }
}
