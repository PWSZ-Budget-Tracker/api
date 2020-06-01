using System.Collections.Generic;

namespace Budget_Tracker.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
