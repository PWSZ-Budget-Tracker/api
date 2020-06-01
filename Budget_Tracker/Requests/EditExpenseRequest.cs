namespace Budget_Tracker.Requests
{
    public class EditExpenseRequest
    {
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
    }
}
