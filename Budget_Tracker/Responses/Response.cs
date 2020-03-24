using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Responses
{
    public class Response
    {
        public bool Successful { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
