using Budget_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class GetExpensesRequest
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
