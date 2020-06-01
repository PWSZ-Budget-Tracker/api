using System;

namespace Budget_Tracker.VievModel
{
    public class IncomeVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public CurrencyVM Currency { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
