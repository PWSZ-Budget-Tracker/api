using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class EditCategoryRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
