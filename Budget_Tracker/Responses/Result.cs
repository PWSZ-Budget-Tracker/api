namespace Budget_Tracker.Responses
{

    public class Result<T> : Response
    {
        public T Payload { get; set; }
    }
}
