﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Requests
{
    public class EditIncomeRequest
    {
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
    }
}