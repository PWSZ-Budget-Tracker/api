﻿namespace Budget_Tracker.Requests
{
    public class AddAmountRequest
    {
        public int GoalId { get; set; }
        public decimal Amount { get; set; }
    }
}
