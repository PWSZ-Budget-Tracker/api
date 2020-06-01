namespace Budget_Tracker.Requests
{
    public class DeleteAmountRequest
    {
        public int GoalId { get; set; }
        public decimal Amount { get; set; }
    }
}
