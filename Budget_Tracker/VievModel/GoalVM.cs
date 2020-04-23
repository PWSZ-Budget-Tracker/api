﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.VievModel
{
    public class GoalVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal GoalAmount { get; set; }
        public CurrencyVM Currency { get; set; }
    }
}
