namespace Budget_Tracker.Requests
{
    public class RegisterRequest : LoginRequest
    {
        public string PasswordConfirmation { get; set; }
    }
}
