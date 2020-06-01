namespace Budget_Tracker.Requests
{
    public class EditGoalRequest
    {
        public int GoalId { get; set; }
        public string Name { get; set; }
        public decimal GoalAmount { get; set; }
    }
}
