using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IActionResult> GetAll(GetCategoriesRequest request);
        public Task<IActionResult> Add(AddCategoryRequest request);
        public Task<IActionResult> Edit(EditCategoryRequest request);
        public Task<IActionResult> Delete(DeleteCategoryRequest request);
    }
}
