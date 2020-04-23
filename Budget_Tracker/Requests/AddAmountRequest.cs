﻿using Budget_Tracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class AddAmountRequest
    {
        public int GoalId { get; set; }
        public decimal Amount { get; set; }
    }
}
