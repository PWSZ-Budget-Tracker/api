namespace Budget_Tracker.Requests
{
    public class AddIncomeRequest
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
    }
}
