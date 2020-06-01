namespace Budget_Tracker.Requests
{
    public class AddGoalRequest
    {
        public string Name { get; set; }
        public decimal GoalAmount { get; set; }
        public int CurrencyId { get; set; }
    }
}
