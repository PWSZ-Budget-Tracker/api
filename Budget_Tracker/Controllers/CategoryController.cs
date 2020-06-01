using Budget_Tracker.Enums;
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
    public class CategoryController :BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
            : base()
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CategoryType type)
        {
                if (!ModelState.IsValid)
                {
                    return Failure();
                }

                return await _categoryService.GetAll(type);
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

        [HttpPut]
        public async Task<IActionResult> Edit(EditCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Failure();
            }

            return await _categoryService.Edit(request);
        }

        [HttpDelete]
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
