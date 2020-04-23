using Budget_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class AddGoalRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal GoalAmount { get; set; }
        public int CurrencyId { get; set; }
    }
}
