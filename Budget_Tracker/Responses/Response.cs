using System.Collections.Generic;

namespace Budget_Tracker.Responses
{
    public class Response
    {
        public bool Successful { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
