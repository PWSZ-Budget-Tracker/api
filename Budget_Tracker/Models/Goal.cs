﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public decimal GoalAmount { get; set; }
    }
}