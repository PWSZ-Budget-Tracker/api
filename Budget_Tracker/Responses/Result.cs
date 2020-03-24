using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Responses
{

    public class Result<T> : Response
    {
        public T Payload { get; set; }
    }
}
