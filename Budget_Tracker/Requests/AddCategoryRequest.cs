using Budget_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
