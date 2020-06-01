namespace Budget_Tracker.Requests
{
    public class AddExpenseRequest
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
    }
}
