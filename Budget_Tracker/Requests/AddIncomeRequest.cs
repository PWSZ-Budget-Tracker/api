using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class AddIncomeRequest
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
    }
}
