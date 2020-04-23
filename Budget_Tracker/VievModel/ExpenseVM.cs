﻿using Budget_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.VievModel
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public CurrencyVM Currency { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}