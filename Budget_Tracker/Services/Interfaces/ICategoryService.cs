﻿using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IActionResult> GetAll();
        public Task<IActionResult> Add(AddCategoryRequest request);
        public Task<IActionResult> Edit(EditCategoryRequest request);
        public Task<IActionResult> Delete(DeleteCategoryRequest request);
    }
}